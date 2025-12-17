using Microsoft.EntityFrameworkCore;
using WeddingHall.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.Interfaces;

namespace WeddingHall.Infrastructure.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _db;
        public DashboardService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetNewRequestCountAsync()
        {
            return await _db.NewRequests.CountAsync();
        }

        public async Task<int> GetTodayBookingCountAsync()
        {
            return await _db.TodayBookings.CountAsync();
        }

        public async Task<decimal> GetTodayBookingTotalAmountAsync()
        {
            return await _db.TodayBookings.SumAsync(b => b.Amount);
        }

        public async Task<int> GetNext15DaysBookingCountAsync()
        {
            return await _db.Next15DaysBookings.CountAsync();
        }

        public async Task<decimal> GetNext15DaysBookingTotalAmountAsync()
        {
            return await _db.Next15DaysBookings.SumAsync(b => b.Amount);
        }

        public async Task<DashboardResponse> GetDashboardAsync()
        {
            return new DashboardResponse
            {
                NewRequestCount = await GetNewRequestCountAsync(),
                TodayBookingCount = await GetTodayBookingCountAsync(),
                TodayBookingTotalAmount = await GetTodayBookingTotalAmountAsync(),
                Next15DaysBookingCount = await GetNext15DaysBookingCountAsync(),
                Next15DaysBookingTotalAmount = await GetNext15DaysBookingTotalAmountAsync()
            };
        }
    }
}
