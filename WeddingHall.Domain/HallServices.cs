using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class HallServices : BaseDomainClass
    {
        public Guid GUID { get; set; }              // PRIMARY KEY
        public Guid HallId { get; set; }            // FK → HallMaster

        public string ServiceName { get; set; } = string.Empty;
        public decimal ServicePrice { get; set; }
        public int ServiceQuantity { get; set; }
        public string? Description { get; set; }

        public HallMaster? Hall { get; set; }
    }
}
