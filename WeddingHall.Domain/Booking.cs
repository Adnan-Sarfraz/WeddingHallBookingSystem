using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int HallId { get; set; }
        
        public DateTime EventDate { get; set; }
        public string TimeSlot { get; set; } = "Day";
        public int Guests { get; set; }
        public bool DinnerRequired { get; set; }
        public string? Notes { get; set; }

    }
}
