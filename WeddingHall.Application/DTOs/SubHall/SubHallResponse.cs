using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.SubHall
{
    public class SubHallResponse
    {
        public Guid GUID { get; set; }
        public Guid Hall_id { get; set; }

        public string SubHall_Name { get; set; } = string.Empty;
        public int Capacity { get; set; }

        // Track our columns
        public Guid? Inserted_By { get; set; }
        public Guid? Updated_By { get; set; }
        public DateTime Inserted_Date { get; set; }
        public DateTime? Updated_Date { get; set; }
        public bool isActive { get; set; }


        public List<Guid> ServiceIds { get; set; } = new(); //ServiceIds
    }
}
