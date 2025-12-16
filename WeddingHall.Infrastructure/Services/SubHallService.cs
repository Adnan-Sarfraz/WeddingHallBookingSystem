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

        public SubHallService(IGenericRepository<SubHallDetail> subHallRepository,
                              IGenericRepository<HallMaster> hallRepository, IMapper mapper)
        {
            _subHallRepository = subHallRepository;
            _hallRepository = hallRepository;
            _mapper = mapper;
        }

        //CREATE
        public async Task<bool> CreateAsync(SubHallCreateRequest request)
        {
            var hall = await _hallRepository.GetByIdAsync(request.Hall_id);
               
            if (hall == null)
                return false;

            var model = _mapper.Map<SubHallDetail>(request);

            await _subHallRepository.AddAsync(model);
            await _subHallRepository.SaveChangesAsync();

            return true;
        }


        //UPDATE
        public async Task<bool> UpdateAsync(SubHallUpdateRequest request)
        {
            var model = (await _subHallRepository.FindAsync(s => s.GUID == request.GUID)).FirstOrDefault();

            if (model == null)
                return false;

            _mapper.Map(request, model); //this updates exsisting entity
            model.Updated_Date = DateTime.Now;

            _subHallRepository.Update(model);
            await _subHallRepository.SaveChangesAsync();

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
            var model = await _subHallRepository.GetByIdAsync(guid);

            if (model == null)
                return null;

            return _mapper.Map<SubHallResponse>(model);
        }


        //GET_ALL
        public async Task<List<SubHallResponse>> GetAllAsync()
        {
            var all = await _subHallRepository.GetAllAsync();
            return _mapper.Map<List<SubHallResponse>>(all);
        }
    }
}
