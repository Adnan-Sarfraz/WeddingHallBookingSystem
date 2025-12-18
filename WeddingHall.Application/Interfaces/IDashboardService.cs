using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs;
using WeddingHall.Domain.ViewModels;
using WeddingHall.Application.DTOs.Dashboard;

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
   
}
