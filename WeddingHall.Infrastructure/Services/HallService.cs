using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.DTOs.Hall;
using WeddingHall.Application.Interfaces;
using WeddingHall.Domain;

namespace WeddingHall.Infrastructure.Services
{
    public class HallService : IHallService
    {
        private readonly ApplicationDbContext _db;

        public HallService(ApplicationDbContext db)
        {
            _db = db;
        }

        //creation of new HallMaster ( POST )
        public async Task<bool> CreateHallAsync(HallCreateRequest request)
        {
            var hall = new HallMaster
            {
                GUID = Guid.NewGuid(),
                HallName = request.HallName,
                HallAddress = request.HallAddress,
                CityId = request.CityId,
                DistrictId = request.DistrictId,
                Inserted_By = request.Inserted_By,
                Inserted_Date = DateTime.Now,
                Updated_By = null,
                Updated_Date = null,
                isActive = true
            };

            _db.HallMasters.Add(hall);
            await _db.SaveChangesAsync();
            return true;
        }
        //Get All ( GET )

        public async Task<List<HallResponse>> GetAllHallsAsync()
        {
            return await _db.HallMasters
                .Include(x => x.City)
                .Include(x => x.District)
                .Select(h => new HallResponse
                {
                    GUID = h.GUID,
                    HallName = h.HallName,
                    HallAddress = h.HallAddress,
                    CityName = h.City!.CityName,
                    DistrictName = h.District!.DistrictName,
                    IsActive = h.isActive
                })
                .ToListAsync();
        }


        //Get by ID ( GET )
        public async Task<HallResponse?> GetHallByIdAsync(Guid id)
        {
            var hall = await _db.HallMasters
                .Include(x => x.City)
                .Include(x => x.District)
                .FirstOrDefaultAsync(x => x.GUID == id);

            if (hall == null)
                return null;

            return new HallResponse
            {
                GUID = hall.GUID,
                HallName = hall.HallName,
                HallAddress = hall.HallAddress,
                CityName = hall.City!.CityName,
                DistrictName = hall.District!.DistrictName,
                IsActive = hall.isActive
            };
        }
        //Update ( PUT )
        public async Task<bool> UpdateHallAsync(HallUpdateRequest request)
        {
            var hall = await _db.HallMasters.FindAsync(request.GUID);

            if (hall == null)
                return false;

            hall.HallName = request.HallName;
            hall.HallAddress = request.HallAddress;
            hall.CityId = request.CityId;
            hall.DistrictId = request.DistrictId;

            hall.Updated_By = request.Updated_By;
            hall.Updated_Date = DateTime.Now;

            await _db.SaveChangesAsync();
            return true;
        }
        ////Delete User ( DELETE )
        public async Task<bool> DeleteHallAsync(Guid id)
        {
            var hall = await _db.HallMasters.FindAsync(id);

            if (hall == null)
                return false;

            hall.isActive = false; //this directly/softly deletes 
            await _db.SaveChangesAsync();
            return true;
        }
    }
}