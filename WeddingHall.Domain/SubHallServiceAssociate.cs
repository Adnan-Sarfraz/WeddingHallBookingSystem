using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class SubHallServiceAssociate : BaseDomainClass
    {
        public Guid GUID { get; set; }

        public Guid SubHall_Id { get; set; }
        public SubHallDetail? SubHall { get; set; } //Navigation property

        public Guid Service_Id { get; set; }
        public HallServices? Service { get; set; } //Navigation property 
    }
}
