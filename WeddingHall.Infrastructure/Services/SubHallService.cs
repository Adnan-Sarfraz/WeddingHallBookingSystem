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

        public SubHallService(IGenericRepository<SubHallDetail> subHallRepository,
                              IGenericRepository<HallMaster> hallRepository)
        {
            _subHallRepository = subHallRepository;
            _hallRepository = hallRepository;
        }

        //CREATE
        public async Task<bool> CreateAsync(SubHallCreateRequest request)
        {
            var hall = await _hallRepository.GetByIdAsync(request.Hall_id);
               
            if (hall == null)
                return false;

            var model = new SubHallDetail
            {
                GUID = Guid.NewGuid(),
                Hall_id = request.Hall_id,
                SubHall_Name = request.SubHall_Name,
                Capacity = request.Capacity,
                Inserted_By = request.Inserted_By,
                Inserted_Date = DateTime.Now,
                isActive = true
            };

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

            model.SubHall_Name = request.SubHall_Name;
            model.Capacity = request.Capacity;
            model.Updated_By = request.Updated_By;
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

            return new SubHallResponse
            {
                GUID = model.GUID,
                Hall_id = model.Hall_id,
                SubHall_Name = model.SubHall_Name,
                Capacity = model.Capacity,
                Inserted_By = model.Inserted_By,
                Updated_By = model.Updated_By,
                Inserted_Date = model.Inserted_Date,
                Updated_Date = model.Updated_Date,
                isActive = model.isActive
            };
        }


        //GET_ALL
        public async Task<List<SubHallResponse>> GetAllAsync()
        {
            var all = await _subHallRepository.GetAllAsync();
            return all.Select(model => new SubHallResponse
            {
                GUID = model.GUID,
                Hall_id = model.Hall_id,
                SubHall_Name = model.SubHall_Name,
                Capacity = model.Capacity,
                Inserted_By = model.Inserted_By,
                Updated_By = model.Updated_By,
                Inserted_Date = model.Inserted_Date,
                Updated_Date = model.Updated_Date,
                isActive = model.isActive
            }).ToList();
        }
    }
}
