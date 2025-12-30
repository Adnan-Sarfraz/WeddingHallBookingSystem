using AutoMapper;
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
        private readonly IHallRepository _hallRepository; //handles database CRUD operations 
        private readonly IMapper _mapper; //injecting automapper 

        public HallService(IHallRepository hallRepository, IMapper mapper)
        {
            _hallRepository = hallRepository;
            _mapper = mapper;

        }

        //creation of new HallMaster ( POST )
        public async Task<bool> CreateHallAsync(HallCreateRequest request)
        {
            var hall = _mapper.Map<HallMaster>(request);

            await _hallRepository.AddAsync(hall);
            await _hallRepository.SaveChangesAsync();

            return true;
        }


        //Get All Halls( GET )
        public async Task<List<HallResponse>> GetAllHallsAsync()
        {
            var halls = await _hallRepository.GetAllWithDetailsAsync();

            return _mapper.Map<List<HallResponse>>(halls); //Automapper used  

        }



        //Get by ID ( GET )
        public async Task<HallResponse?> GetHallByIdAsync(Guid id)
        {
            var hall = await _hallRepository.GetByIdWithDetailsAsync(id);

            if (hall == null)
                return null;

            return _mapper.Map<HallResponse>(hall); //Automapper used 
        }


        //Update Hall ( PUT )
        public async Task<bool> UpdateHallAsync(HallUpdateRequest request)
        {
            var hall = await _hallRepository.GetByIdAsync(request.GUID);

            if (hall == null)
                return false;

            _mapper.Map(request, hall);

           // hall.Updated_By = request.Updated_By;
           // hall.Updated_Date = DateTime.Now;

            _hallRepository.Update(hall);
            await _hallRepository.SaveChangesAsync();

            return true; 

        }


        //Delete Hall ( DELETE )
        public async Task<bool> DeleteHallAsync(Guid id)
        {
            var hall = await _hallRepository.GetByIdAsync(id);

            if (hall == null)
                return false;

            //hall.Updated_Date = DateTime.Now;

            hall.isActive = false; //this directly/softly deletes 
            _hallRepository.Update(hall);
            await _hallRepository.SaveChangesAsync();
            return true;
        }
    }
}