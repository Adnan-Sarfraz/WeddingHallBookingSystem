using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Infrastructure;

namespace WeddingHall.Infrastructure.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _db;

        public DashboardRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> GetNewRequestCountAsync()
            => await _db.NewRequests.CountAsync();

        public async Task<int> GetTodayBookingCountAsync()
            => await _db.TodayBookings.CountAsync();

        public async Task<decimal> GetTodayBookingTotalAmountAsync()
            => await _db.TodayBookings.SumAsync(x => x.Amount);

        public async Task<int> GetNext15DaysBookingCountAsync()
            => await _db.Next15DaysBookings.CountAsync();

        public async Task<decimal> GetNext15DaysBookingTotalAmountAsync()
            => await _db.Next15DaysBookings.SumAsync(x => x.Amount);
    }
}
