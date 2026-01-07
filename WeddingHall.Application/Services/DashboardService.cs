using Microsoft.EntityFrameworkCore;
using WeddingHall.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.DTOs.Dashboard;
using WeddingHall.Application.Interfaces.Repositories;


namespace WeddingHall.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<DashboardResponse> GetDashboardAsync()
        {
            return new DashboardResponse
            {
                NewRequestCount = await _dashboardRepository.GetNewRequestCountAsync(),
                TodayBookingCount = await _dashboardRepository.GetTodayBookingCountAsync(),
                TodayBookingTotalAmount = await _dashboardRepository.GetTodayBookingTotalAmountAsync(),
                Next15DaysBookingCount = await _dashboardRepository.GetNext15DaysBookingCountAsync(),
                Next15DaysBookingTotalAmount = await _dashboardRepository.GetNext15DaysBookingTotalAmountAsync()
            };

        }
    }
}
