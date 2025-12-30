using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.DTOs.DropDown;
using WeddingHall.Infrastructure;


namespace WeddingHall.Infrastructure.Services
{
    public class DropdownService:IDropdownService
    {
        private readonly ApplicationDbContext _context;

        public DropdownService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<DropdownResponse>> GetCitiesAsync()
        {
            return await _context.Cities
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.Guid,
                    Name = x.CityName
                })
                .ToListAsync();
        }
        public async Task<List<DropdownResponse>> GetDistrictsAsync()
        {
            return await _context.Districts
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.Guid,
                    Name = x.DistrictName
                })
                .ToListAsync();
        }
        public async Task<List<DropdownResponse>> GetRolesAsync()
        {
            return await _context.Roles
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.GUID,
                    Name = x.RoleName
                })
                .ToListAsync();
        }
        public async Task<List<DropdownResponse>> GetHallsAsync()
        {
            return await _context.HallMasters
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.GUID,
                    Name = x.HallName
                })
                .ToListAsync();
        }

        public async Task<List<DropdownResponse>> GetUsersAsync()
        {
            return await _context.UserManagers
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.GUID,
                    Name = x.UserName
                })
                .ToListAsync();
        }

        public async Task<List<DropdownResponse>> GetHallServicesAsync()
        {
            return await _context.HallServices
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.GUID,
                    Name = x.ServiceName
                })
                .ToListAsync();
        }

        public async Task<List<DropdownResponse>> GetSubHallsAsync()
        {
            return await _context.SubHallDetails
                .Where(x => x.isActive)
                .Select(x => new DropdownResponse
                {
                    Id = x.GUID,
                    Name = x.SubHall_Name
                })
                .ToListAsync();
        }
    }
}
