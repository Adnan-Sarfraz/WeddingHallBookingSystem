using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.SubHall
{
    public class SubHallCreateRequest
    {
        public Guid Hall_id { get; set; }   // The GUID of the HallMaster to which this SubHall belongs
        public string SubHall_Name { get; set; } = string.Empty;
        public int Capacity { get; set; }

     
        public Guid? Inserted_By { get; set; }   // who created the record
    }
}
