using AutoMapper;
//using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.DTOs.Hall;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Domain;

namespace WeddingHall.Application.Services
{
    public class HallService : IHallService
    {
        private readonly IHallRepository _hallRepository; //handles database CRUD operations 
        private readonly IMapper _mapper; //injecting automapper 

        public HallService(IHallRepository hallRepository, IMapper mapper)
        {
            _hallRepository = hallRepository;
            _mapper = mapper;

        }

        public async Task<bool> CreateHallAsync(HallCreateRequest request)
        {
            var hall = _mapper.Map<HallMaster>(request);

            await _hallRepository.AddAsync(hall);
            await _hallRepository.SaveChangesAsync();

            return true;
        }

        public async Task<List<HallResponse>> GetAllHallsAsync()
        {
            var halls = await _hallRepository.GetAllWithDetailsAsync();

            return _mapper.Map<List<HallResponse>>(halls); //Automapper used  

        }

        public async Task<HallResponse?> GetHallByIdAsync(Guid id)
        {
            var hall = await _hallRepository.GetByIdWithDetailsAsync(id);

            if (hall == null)
                return null;

            return _mapper.Map<HallResponse>(hall); //Automapper used 
        }

        public async Task<bool> UpdateHallAsync(HallUpdateRequest request)
        {
            var hall = await _hallRepository.GetByIdAsync(request.GUID);

            if (hall == null)
                return false;

            _mapper.Map(request, hall);

            _hallRepository.Update(hall);
            await _hallRepository.SaveChangesAsync();

            return true; 

        }

        public async Task<bool> DeleteHallAsync(Guid id)
        {
            var hall = await _hallRepository.GetByIdAsync(id);

            if (hall == null)
                return false;


            hall.isActive = false; 
            _hallRepository.Update(hall);
            await _hallRepository.SaveChangesAsync();
            return true;
        }
    }
}