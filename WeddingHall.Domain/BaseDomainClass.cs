using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public abstract class BaseDomainClass
    {
        public Guid? Inserted_By { get; set; }
        public Guid? Updated_By {  get; set; }
        public DateTime Inserted_Date { get; set; }
        public DateTime? Updated_Date { get; set;}

        public bool isActive { get; set; }


    }
}
