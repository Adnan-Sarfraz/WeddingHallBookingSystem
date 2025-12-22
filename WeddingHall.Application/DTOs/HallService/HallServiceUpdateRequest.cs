using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.HallService
{
    public class HallServiceUpdateRequest
    {
        public Guid GUID { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public decimal ServicePrice { get; set; }
        public int ServiceQuantity { get; set; }
        public string? Description { get; set; }
        public Guid? Updated_By { get; set; }
    }
}
