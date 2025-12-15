using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.Hall
{
    public class HallUpdateRequest
    {
        public Guid GUID { get; set; }

        public string HallName { get; set; } = string.Empty;
        public string HallAddress { get; set; } = string.Empty;

        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }

        public Guid Updated_By { get; set; }
    }
}
