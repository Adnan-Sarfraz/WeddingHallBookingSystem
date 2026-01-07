using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Domain.ViewModels;

namespace WeddingHall.Application.Interfaces.Repositories
{
    public interface IDashboardRepository
    {
        Task<int> GetNewRequestCountAsync();
        Task<int> GetTodayBookingCountAsync();
        Task<decimal> GetTodayBookingTotalAmountAsync();
        Task<int> GetNext15DaysBookingCountAsync();
        Task<decimal> GetNext15DaysBookingTotalAmountAsync();
    }
}
