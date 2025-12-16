using AutoMapper;
using WeddingHall.Application.DTOs.SignIn;
using WeddingHall.Application.DTOs.UserRegistration;
using WeddingHall.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.Mappings
{
    public class UserProfile: Profile 
    {
        public UserProfile()
        {
            
            CreateMap<UserRegistrationRequest, Users>()
                 .ForMember(d => d.Password, o => o.Ignore());

            // SignInResponse
            CreateMap<Users, SignInResponse>()
               .ForMember(d => d.Role,
                    o => o.MapFrom(s => s.Role != null ? s.Role.RoleName : "USER"));
        }
    }
}
