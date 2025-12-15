using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Domain;



namespace WeddingHall.Infrastructure.Repositories
{
    public class HallRepository: GenericRepository<HallMaster>, IHallRepository
    {
        public HallRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        // Get all halls WITH City and District
        public async Task<IEnumerable<HallMaster>> GetAllWithDetailsAsync()
        {
            return await _context.HallMasters
                .Include(h => h.City)
                .Include(h => h.District)
                .Where(h => h.isActive) // soft delete respected
                .ToListAsync();
        }

        // Get single hall WITH City and District
        public async Task<HallMaster?> GetByIdWithDetailsAsync(Guid id)
        {
            return await _context.HallMasters
                .Include(h => h.City)
                .Include(h => h.District)
                .FirstOrDefaultAsync(h => h.GUID == id && h.isActive);
        }
    }
}
