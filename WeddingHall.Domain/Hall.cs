using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class Hall
    {
        public int Id { get; set; }
        public string HallName { get; set; } = string.Empty;
        public string ManagerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; } = 0;
        public decimal PriceWithDinner { get; set; } = 0m;

        public decimal PriceWithoutDinner { get; set; } = 0;

    }
}
