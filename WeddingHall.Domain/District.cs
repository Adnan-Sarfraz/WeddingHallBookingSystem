using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class District : BaseDomainClass
    {
        public Guid Guid { get; set; }  // Primary Key or Guid of district
        public string DistrictName { get; set; } = string.Empty;

        public Guid DisctrictCode { get; set; } // Normal column, NOT PK
    }
}
