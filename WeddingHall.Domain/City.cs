using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class City : BaseDomainClass
    {
        public Guid Guid { get; set; }  // Primary Key of Guid of City
        public string CityName { get; set; } = string.Empty;

        public Guid CityCode { get; set; } // Normal column

        public Guid? Districtode { get; set; } // FK → District.DisctrictCode

        //Nvaigation property
        public District? District { get; set; }
    }
    
}
