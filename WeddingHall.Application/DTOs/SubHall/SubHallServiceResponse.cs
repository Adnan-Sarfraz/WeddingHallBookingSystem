using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.SubHall
{
    public class SubHallServiceResponse
    {
        public Guid Service_Id { get; set; }
        public string Service_Name { get; set; }=string.Empty;
    }
}
