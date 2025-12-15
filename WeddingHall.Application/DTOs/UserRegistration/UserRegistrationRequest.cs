using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.UserRegistration
{
    public class UserRegistrationRequest
    {
        public string FullName { get; set; }=string.Empty;
        public string Address { get; set; }=string.Empty;
        public Guid CityID { get; set; }
        public Guid DistrictID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid RoleID { get; set; }
        public string UserType { get; set; } = string.Empty;
     





    }
}
