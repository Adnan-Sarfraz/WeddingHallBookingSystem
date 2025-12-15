using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class Availability
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        public DateTime Date { get; set; }
        public string Slot { get; set; } = "Day"; // Day/Night
        public bool IsAvailable { get; set; } = true;
    }
}
