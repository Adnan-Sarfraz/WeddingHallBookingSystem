using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.Hall
{
    public class HallResponse
    {
        public Guid GUID { get; set; }
        public string HallName { get; set; } = string.Empty;
        public string HallAddress { get; set; } = string.Empty;

        public string? CityName { get; set; }
        public string DistrictName { get; set; } = string.Empty;

        public bool IsActive { get; set; }

    }
}
