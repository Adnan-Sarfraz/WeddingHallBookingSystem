using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.SubHall;


namespace WeddingHall.Application.Interfaces
{
    public interface ISubHallService
    {
        Task<bool> CreateAsync(SubHallCreateRequest request);
        Task<bool> UpdateAsync(SubHallUpdateRequest request);
        Task<bool> DeleteAsync(Guid guid);
        Task<SubHallResponse?> GetByIdAsync(Guid guid);
        Task<List<SubHallResponse>> GetAllAsync();

    }
}
