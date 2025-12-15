using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class Users : BaseDomainClass
    {
        public Guid GUID { get; set; }   // Primary Key of users

        public string UserName { get; set; } = string.Empty;

        public Guid RoleId { get; set; }      // FK → Role.GUID
        public Guid? HallId { get; set; }     // FK → HallMaster.GUID (Nullable for Admin)

        public string PhoneNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Guid CityId { get; set; }    // Foreign Key Guid Of city
        public Guid DistrictId { get; set; }

        // Navigation Properties
        //They are used to move (navigate) from one table to another related table in C# code.
        public Role? Role { get; set; }
        public HallMaster? HallMaster { get; set; }
        public City? City { get; set; }
        public District? District { get; set; }
    }
}
