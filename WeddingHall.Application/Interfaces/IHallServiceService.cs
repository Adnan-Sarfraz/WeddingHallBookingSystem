using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.HallService;
using WeddingHall.Domain;

namespace WeddingHall.Application.Interfaces
{
    public interface IHallServiceService
    {
        Task<bool> CreateAsync(HallServiceCreateRequest request);
        Task<bool> UpdateAsync(HallServiceUpdateRequest request);
        Task<bool> DeleteAsync(Guid guid);
        Task<HallServiceResponse?> GetByIdAsync(Guid guid);
        Task<List<HallServiceResponse>> GetByHallIdAsync(Guid hallId);
    }
}
