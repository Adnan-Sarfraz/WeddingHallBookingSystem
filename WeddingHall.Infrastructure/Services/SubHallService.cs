using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingHall.Application.DTOs.SubHall;
using WeddingHall.Application.Interfaces;
using WeddingHall.Application.Interfaces.Repositories;
using WeddingHall.Domain;

namespace WeddingHall.Infrastructure.Services
{
    public class SubHallService: ISubHallService
    {
        private readonly IGenericRepository<SubHallDetail> _subHallRepository;
        private readonly IGenericRepository<HallMaster> _hallRepository;
        private readonly IMapper _mapper; //Injecting AutoMapper 
        private readonly IGenericRepository<SubHallServiceAssociate> _subHallServiceRepo;


        public SubHallService(IGenericRepository<SubHallDetail> subHallRepository, IGenericRepository<SubHallServiceAssociate> subHallServiceRepo,
                              IGenericRepository<HallMaster> hallRepository, IMapper mapper)
        {
            _subHallRepository = subHallRepository;
            _hallRepository = hallRepository;
            _mapper = mapper;
            _subHallServiceRepo = subHallServiceRepo;
        }

        //CREATE
        public async Task<bool> CreateAsync(SubHallCreateRequest request)
        {
            //  Check Hall exists
            var hall = await _hallRepository.GetByIdAsync(request.Hall_id);
            if (hall == null)
                return false;

            // Create SubHall
            var model = _mapper.Map<SubHallDetail>(request);
            model.GUID = Guid.NewGuid();
            model.Inserted_Date = DateTime.Now;
            model.isActive = true;

            await _subHallRepository.AddAsync(model);
            await _subHallRepository.SaveChangesAsync();

            // Create SubHall ↔ Service associations
            if (request.ServiceIds != null && request.ServiceIds.Any())
            {
                foreach (var serviceId in request.ServiceIds)
                {
                    var associate = new SubHallServiceAssociate
                    {
                        GUID = Guid.NewGuid(),
                        SubHall_Id = model.GUID,
                        Service_Id = serviceId,
                        Inserted_Date = DateTime.Now,
                        isActive = true
                    };

                    await _subHallServiceRepo.AddAsync(associate);
                }

                await _subHallServiceRepo.SaveChangesAsync();
            }

            return true;
        }

      

        //UPDATE
        public async Task<bool> UpdateAsync(SubHallUpdateRequest request)
        {
            var model = (await _subHallRepository
                .FindAsync(s => s.GUID == request.GUID))
                .FirstOrDefault();

            if (model == null)
                return false;

            //Update time automatically
            _mapper.Map(request, model);
            model.Updated_Date = DateTime.Now;

            _subHallRepository.Update(model);
            await _subHallRepository.SaveChangesAsync();

            // Remove old service associations
            var existingAssociations = await _subHallServiceRepo
                .FindAsync(x => x.SubHall_Id == model.GUID);

            foreach (var item in existingAssociations)
            {
                _subHallServiceRepo.Delete(item);
            }

            await _subHallServiceRepo.SaveChangesAsync();

            // Add new service associations
            if (request.ServiceIds != null && request.ServiceIds.Any())
            {
                foreach (var serviceId in request.ServiceIds)
                {
                    var associate = new SubHallServiceAssociate
                    {
                        GUID = Guid.NewGuid(),
                        SubHall_Id = model.GUID,
                        Service_Id = serviceId,
                        Inserted_Date = DateTime.Now,
                        isActive = true
                    };

                    await _subHallServiceRepo.AddAsync(associate);
                }

                await _subHallServiceRepo.SaveChangesAsync();
            }

            return true;
        }

        //DELETE
        public async Task<bool> DeleteAsync(Guid guid)
        {
            var model = (await _subHallRepository.FindAsync(s => s.GUID == guid)).FirstOrDefault();
            if (model == null)
                return false;

            model.isActive = false; // Soft delete
            model.Updated_Date = DateTime.Now;

            _subHallRepository.Update(model);
            await _subHallRepository.SaveChangesAsync();
            return true;
        }



        //GET_BY_ID
        public async Task<SubHallResponse?> GetByIdAsync(Guid guid)
        {
            var model = await _subHallRepository
                .Query()
                .Include(s => s.SubHallServiceAssociates)
                .ThenInclude(sa => sa.Service)
                .FirstOrDefaultAsync(s => s.GUID == guid && s.isActive);
            if (model == null)
                return null;

            var response = _mapper.Map<SubHallResponse>(model); response
                .Services = model.SubHallServiceAssociates
                .Select(sa => new SubHallServiceResponse
                {
                    Service_Id = sa.Service_Id,
                    Service_Name = sa.Service.ServiceName
                })
                .ToList();

            return response;
        }


        //GetAllAsync
        public async Task<List<SubHallResponse>> GetAllAsync()
        {
            var models = await _subHallRepository
                .Query()
                .Include(s => s.SubHallServiceAssociates)
                    .ThenInclude(sa => sa.Service)
                .Where(s => s.isActive)
                .ToListAsync();

            var responseList = models.Select(model =>
            {
                var response = _mapper.Map<SubHallResponse>(model);

                response.Services = model.SubHallServiceAssociates
                    .Where(sa => sa.isActive)
                    .Select(sa => new SubHallServiceResponse
                    {
                        Service_Id = sa.Service_Id,
                        Service_Name = sa.Service.ServiceName
                    })
                    .ToList();

                return response;
            }).ToList();

            return responseList;
        }

    }
}
