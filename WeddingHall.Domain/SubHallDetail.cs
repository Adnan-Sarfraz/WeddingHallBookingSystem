using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class SubHallDetail : BaseDomainClass
    {
        public Guid GUID { get; set; }   // Primary Key

        public Guid Hall_id { get; set; }  // Foreign Key → HallMaster.GUID

        public string SubHall_Name { get; set; } = string.Empty;
        public int Capacity { get; set; }

        // Navigation Property (Professional)
        //They are used to move (navigate) from one table to another related table in C# code.
        public HallMaster? HallMaster { get; set; }


        public ICollection<SubHallServiceAssociate> SubHallServiceAssociates { get; set; }
          = new List<SubHallServiceAssociate>();

    }
}
