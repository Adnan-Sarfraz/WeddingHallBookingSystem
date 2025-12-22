// WeddingHall.Infrastructure / Services / HallServiceService.cs
using AutoMapper;
using WeddingHall.Application.DTOs.HallService;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Domain;

namespace WeddingHall.Infrastructure.Services
{
    public class HallServiceService : IHallServiceService
    {
        private readonly IGenericRepository<HallServices> _serviceRepo;
        private readonly IGenericRepository<HallMaster> _hallRepo;
        private readonly IMapper _mapper;

        public HallServiceService(
            IGenericRepository<HallServices> serviceRepo,
            IGenericRepository<HallMaster> hallRepo,
            IMapper mapper)
        {
            _serviceRepo = serviceRepo;
            _hallRepo = hallRepo;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(HallServiceCreateRequest request)
        {
            var hall = await _hallRepo.GetByIdAsync(request.HallId);
            if (hall == null) return false;

            var entity = _mapper.Map<HallServices>(request);
            entity.GUID = Guid.NewGuid();
            entity.Inserted_Date = DateTime.Now;
            entity.isActive = true;

            await _serviceRepo.AddAsync(entity);
            await _serviceRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(HallServiceUpdateRequest request)
        {
            var entity = await _serviceRepo.GetByIdAsync(request.GUID);
            if (entity == null) return false;

            _mapper.Map(request, entity);
            //entity.Updated_Date = DateTime.Now;

            _serviceRepo.Update(entity);
            await _serviceRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid guid)
        {
            var entity = await _serviceRepo.GetByIdAsync(guid);
            if (entity == null) return false;

            entity.isActive = false;
            entity.Updated_Date = DateTime.Now;

            _serviceRepo.Update(entity);
            await _serviceRepo.SaveChangesAsync();
            return true;
        }

        public async Task<HallServiceResponse?> GetByIdAsync(Guid guid)
        {
            var entity = await _serviceRepo.GetByIdAsync(guid);
            return entity == null ? null : _mapper.Map<HallServiceResponse>(entity);
        }

        public async Task<List<HallServiceResponse>> GetByHallIdAsync(Guid hallId)
        {
            var list = await _serviceRepo.FindAsync(
                s => s.HallId == hallId && s.isActive);

            return _mapper.Map<List<HallServiceResponse>>(list);
        }
    }
}



//using AutoMapper;
//using WeddingHall.Application.DTOs.HallService;
//using WeddingHall.Application.Interfaces;
//using WeddingHall.Application.Interfaces.Repositories;
//using WeddingHall.Domain;



//namespace WeddingHall.Infrastructure.Services
//{
//    public class HallServiceService : IHallServiceService
//    {
//        private readonly IGenericRepository<HallService> _serviceRepo;
//        private readonly IGenericRepository<HallMaster> _hallRepo;
//        private readonly IMapper _mapper;

//        public HallServiceService(
//            IGenericRepository<HallService> serviceRepo,
//            IGenericRepository<HallMaster> hallRepo,
//            IMapper mapper)
//        {
//            _serviceRepo = serviceRepo;
//            _hallRepo = hallRepo;
//            _mapper = mapper;
//        }

//        public async Task<bool> CreateAsync(HallServiceCreateRequest request)
//        {
//            var hall = await _hallRepo.GetByIdAsync(request.HallId);
//            if (hall == null) return false;

//            var entity = _mapper.Map<HallService>(request);
//            entity.GUID = Guid.NewGuid();
//            entity.Inserted_Date = DateTime.Now;
//            entity.isActive = true;

//            await _serviceRepo.AddAsync(entity);
//            await _serviceRepo.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> UpdateAsync(HallServiceUpdateRequest request)
//        {
//            var entity = await _serviceRepo.GetByIdAsync(request.GUID);
//            if (entity == null) return false;

//            _mapper.Map(request, entity);
//            entity.Updated_Date = DateTime.Now;

//            _serviceRepo.Update(entity);
//            await _serviceRepo.SaveChangesAsync();
//            return true;
//        }

//        public async Task<bool> DeleteAsync(Guid guid)
//        {
//            var entity = await _serviceRepo.GetByIdAsync(guid);
//            if (entity == null) return false;

//            entity.isActive = false;
//            entity.Updated_Date = DateTime.Now;

//            _serviceRepo.Update(entity);
//            await _serviceRepo.SaveChangesAsync();
//            return true;
//        }

//        public async Task<HallServiceResponse?> GetByIdAsync(Guid guid)
//        {
//            var entity = await _serviceRepo.GetByIdAsync(guid);
//            return entity == null ? null : _mapper.Map<HallServiceResponse>(entity);
//        }

//        public async Task<List<HallServiceResponse>> GetByHallIdAsync(Guid hallId)
//        {
//            var list = await _serviceRepo.FindAsync(
//                s => s.HallId == hallId && s.isActive);

//            return _mapper.Map<List<HallServiceResponse>>(list);
//        }
//    }
//}
