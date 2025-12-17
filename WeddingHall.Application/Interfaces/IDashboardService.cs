using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs;
using WeddingHall.Domain.ViewModels;

namespace WeddingHall.Application.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetNewRequestCountAsync();
        Task<int> GetTodayBookingCountAsync();
        Task<decimal> GetTodayBookingTotalAmountAsync();
        Task<int> GetNext15DaysBookingCountAsync();
        Task<decimal> GetNext15DaysBookingTotalAmountAsync();

        // Optional: Return combined DTO for dashboard
        Task<DashboardResponse> GetDashboardAsync();
    }
    public class DashboardResponse
    {
        public int NewRequestCount { get; set; }
        public int TodayBookingCount { get; set; }
        public decimal TodayBookingTotalAmount { get; set; }
        public int Next15DaysBookingCount { get; set; }
        public decimal Next15DaysBookingTotalAmount { get; set; }
    }
}
