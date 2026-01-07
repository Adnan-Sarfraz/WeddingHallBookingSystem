using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WeddingHall.Application.DTOs.SignIn;
using WeddingHall.Application.DTOs.UserRegistration;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Domain;
using AutoMapper;

namespace WeddingHall.Infrastructure.Services
{
    public class UserService : IUserService
    {
       
        private readonly IGenericRepository<Users> _userRepository;
        private readonly PasswordHasher<Users> _passwordHasher;
        private readonly IConfiguration _config; //use to access configuration settings "appsettings"
        private readonly IMapper _mapper; // Inject AutoMapper

        public UserService(IGenericRepository<Users> userRepository, IConfiguration config, IMapper mapper)
        {
           
            _userRepository = userRepository;
            _passwordHasher = new PasswordHasher<Users>();
            _config = config;
            _mapper = mapper;
        }

        //User Registeration 
        public async Task<bool> RegisterUserAsync(UserRegistrationRequest request)
        {
            // for already exsisting email or checking exsisting emails 
            var existsList = await _userRepository.FindAsync(u => u.Email == request.Email);

            if (existsList.Any())
                return false;         
     
            var user = _mapper.Map<Users>(request); // Use AutoMapper

            user.GUID = Guid.NewGuid();
            user.UserName = request.FullName;
            user.Address = request.Address;
            user.CityId = request.CityID;
            user.DistrictId = request.DistrictID;
            user.PhoneNo = "";
            user.Email = request.Email;

            user.RoleId = request.RoleID;
            user.HallId = null;               

           
            // Hash Passwrod convert 
            user.Password = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }


        //Sign In
        public async Task<SignInResponse?> SignInAsync(SignInRequest request)
        {
            
            var user = await _userRepository
             .Query()
             .Include(u => u.Role)
             .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                return null;

            if (user.Role == null)
                throw new Exception("User has no role assigned. Data integrity issue.");

            // Verification of  hashed password
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
           
            if (result != PasswordVerificationResult.Success)
                return null;
           
            // Create JWT Token
            var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
            var tokenHandler = new JwtSecurityTokenHandler();

            // store data
            var claims = new[]
            {               
                new Claim(ClaimTypes.NameIdentifier, user.GUID.ToString()),
                new Claim(ClaimTypes.Email, user.Email), //Compare both incomming and stored requests 
                new Claim(ClaimTypes.Role, user.Role.RoleName),
                new Claim("UserName", user.UserName)
            };


            //lock the token so nobody can change it 
            var cred = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature //Algorithm
            );


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(6),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = cred
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new SignInResponse
            {
                Token = tokenHandler.WriteToken(token),
                UserId = user.GUID,
                UserName = user.UserName,
                Role = user.Role.RoleName
            };
        }
    }
}
