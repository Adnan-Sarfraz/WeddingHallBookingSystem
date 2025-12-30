using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class HallMaster: BaseDomainClass
    {
        public Guid GUID { get; set; }   // Primary Key

        public string HallName { get; set; } = string.Empty;
        public string HallAddress { get; set; } = string.Empty;

        public Guid CityId { get; set; }      // Foreign Key Guid Of city
        public Guid DistrictId { get; set; }  //Forign key of District  


        // Navigation Property
        public City? City { get; set; }
        public District? District { get; set; }



        

    }


}
