using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingHall.Application.DTOs.Dashboard
{
    public class DashboardResponse
    {
        public int NewRequestCount { get; set; }
        public int TodayBookingCount { get; set; }
        public decimal TodayBookingTotalAmount { get; set; }
        public int Next15DaysBookingCount { get; set; }
        public decimal Next15DaysBookingTotalAmount { get; set; }
    }
}
