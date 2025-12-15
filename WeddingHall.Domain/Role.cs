using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class Role : BaseDomainClass 
    {
        public Guid GUID { get; set; }   // Primary Key

        public string RoleName { get; set; } = string.Empty;
        public string RoleCode { get; set; } = string.Empty;

  
    }

}
