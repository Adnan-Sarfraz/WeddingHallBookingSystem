using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.DTOs.Hall;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Domain;

namespace WeddingHall.Infrastructure.Services
{
    public class HallService : IHallService
    {
        //private readonly ApplicationDbContext _db;
        private readonly IHallRepository _hallRepository;
        public HallService(IHallRepository hallRepository)
        {
            _hallRepository = hallRepository;

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


            await _hallRepository.AddAsync(hall);
            await _hallRepository.SaveChangesAsync();
            return true;
        }


        //Get All ( GET )
        public async Task<List<HallResponse>> GetAllHallsAsync()
        {
            var halls = await _hallRepository.GetAllWithDetailsAsync();

            return halls.Select(h => new HallResponse
            {
                GUID = h.GUID,
                HallName = h.HallName,
                HallAddress = h.HallAddress,
                CityName = h.City?.CityName ?? string.Empty,
                DistrictName = h.District?.DistrictName ?? string.Empty,
                IsActive = h.isActive
            }).ToList();

        }



        //Get by ID ( GET )
        public async Task<HallResponse?> GetHallByIdAsync(Guid id)
        {
            var hall = await _hallRepository.GetByIdWithDetailsAsync(id);

            if (hall == null)
                return null;

            return new HallResponse
            {
                GUID = hall.GUID,
                HallName = hall.HallName,
                HallAddress = hall.HallAddress,
                CityName = hall.City?.CityName ?? string.Empty,
                DistrictName = hall.District?.DistrictName ?? string.Empty,
                IsActive = hall.isActive
            };
        }


        //Update ( PUT )
        public async Task<bool> UpdateHallAsync(HallUpdateRequest request)
        {
            var hall = await _hallRepository.GetByIdAsync(request.GUID);

            if (hall == null)
                return false;

            hall.HallName = request.HallName;
            hall.HallAddress = request.HallAddress;
            hall.CityId = request.CityId;
            hall.DistrictId = request.DistrictId;

            hall.Updated_By = request.Updated_By;
            hall.Updated_Date = DateTime.Now;

            _hallRepository.Update(hall);
            await _hallRepository.SaveChangesAsync();

            return true; 

        }


        ////Delete User ( DELETE )
        public async Task<bool> DeleteHallAsync(Guid id)
        {
            var hall = await _hallRepository.GetByIdAsync(id);

            if (hall == null)
                return false;

            hall.isActive = false; //this directly/softly deletes 

            _hallRepository.Update(hall);
            await _hallRepository.SaveChangesAsync();
            return true;
        }
    }
}