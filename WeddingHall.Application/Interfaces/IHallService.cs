using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.Hall;

namespace WeddingHall.Application.Interfaces
{
    public interface IHallService
    {
        Task<bool> CreateHallAsync(HallCreateRequest request);
        Task<List<HallResponse>> GetAllHallsAsync();
        Task<HallResponse?> GetHallByIdAsync(Guid id);
        Task<bool> UpdateHallAsync(HallUpdateRequest request);
        Task<bool> DeleteHallAsync(Guid id);
    }
}
