using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Domain.ViewModels
{
    public class TodayBookingView
    {
        public Guid BookingId { get; set; }
        public Guid HallId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
