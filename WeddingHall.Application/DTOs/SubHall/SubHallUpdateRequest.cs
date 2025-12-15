using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.SubHall
{
    public class SubHallUpdateRequest
    {
        public Guid GUID { get; set; }  // SubHall ID
        public string SubHall_Name { get; set; } = string.Empty;
        public int Capacity { get; set; }

        // To track who updated the record
        public Guid? Updated_By { get; set; }
    }
}
