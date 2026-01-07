using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.DropDown;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Infrastructure;

namespace WeddingHall.Infrastructure.Repositories
{
    public class DropdownRepository : IDropdownRepository
    {
        private readonly ApplicationDbContext _db;

        public DropdownRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<DropdownResponse>> GetCitiesAsync() =>
            await _db.Cities
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.Guid, Name = x.CityName })
                     .ToListAsync();

        public async Task<List<DropdownResponse>> GetDistrictsAsync() =>
            await _db.Districts
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.Guid, Name = x.DistrictName })
                     .ToListAsync();

        public async Task<List<DropdownResponse>> GetRolesAsync() =>
            await _db.Roles
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.GUID, Name = x.RoleName })
                     .ToListAsync();

        public async Task<List<DropdownResponse>> GetHallsAsync() =>
            await _db.HallMasters
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.GUID, Name = x.HallName })
                     .ToListAsync();

        public async Task<List<DropdownResponse>> GetUsersAsync() =>
            await _db.UserManagers
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.GUID, Name = x.UserName })
                     .ToListAsync();

        public async Task<List<DropdownResponse>> GetHallServicesAsync() =>
            await _db.HallServices
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.GUID, Name = x.ServiceName })
                     .ToListAsync();

        public async Task<List<DropdownResponse>> GetSubHallsAsync() =>
            await _db.SubHallDetails
                     .Where(x => x.isActive)
                     .Select(x => new DropdownResponse { Id = x.GUID, Name = x.SubHall_Name })
                     .ToListAsync();
    }
}
