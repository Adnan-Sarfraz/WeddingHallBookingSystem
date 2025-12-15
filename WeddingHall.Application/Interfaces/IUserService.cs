using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.SignIn;
using WeddingHall.Application.DTOs.UserRegistration;

namespace WeddingHall.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegistrationRequest request);
        Task<SignInResponse?> SignInAsync(SignInRequest request);


    }


}
