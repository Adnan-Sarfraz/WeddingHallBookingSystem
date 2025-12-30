using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.DropDown;

namespace WeddingHall.Application.Interfaces
{
    public interface IDropdownService
    {
        Task<List<DropdownResponse>> GetCitiesAsync();
        Task<List<DropdownResponse>> GetDistrictsAsync();
        Task<List<DropdownResponse>> GetRolesAsync();
        Task<List<DropdownResponse>> GetHallsAsync();
        Task<List<DropdownResponse>> GetUsersAsync();
        Task<List<DropdownResponse>> GetHallServicesAsync();
        Task<List<DropdownResponse>> GetSubHallsAsync();

    }
}
