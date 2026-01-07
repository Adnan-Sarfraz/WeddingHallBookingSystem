using System.Collections.Generic;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.DropDown;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.Interfaces.Repositories;

namespace WeddingHall.Application.Services
{
    public class DropdownService : IDropdownService
    {
        private readonly IDropdownRepository _repository;

        public DropdownService(IDropdownRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DropdownResponse>> GetCitiesAsync() =>
            await _repository.GetCitiesAsync();

        public async Task<List<DropdownResponse>> GetDistrictsAsync() =>
            await _repository.GetDistrictsAsync();

        public async Task<List<DropdownResponse>> GetRolesAsync() =>
            await _repository.GetRolesAsync();

        public async Task<List<DropdownResponse>> GetHallsAsync() =>
            await _repository.GetHallsAsync();

        public async Task<List<DropdownResponse>> GetUsersAsync() =>
            await _repository.GetUsersAsync();

        public async Task<List<DropdownResponse>> GetHallServicesAsync() =>
            await _repository.GetHallServicesAsync();

        public async Task<List<DropdownResponse>> GetSubHallsAsync() =>
            await _repository.GetSubHallsAsync();
    }
}
