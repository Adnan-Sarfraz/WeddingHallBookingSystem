using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeddingHall.Application.Interfaces.Repositories;


namespace WeddingHall.Infrastructure.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        //Get By ID
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        //Get All
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        //Find Data
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        //Add Data
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        //Update Data
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        //Delete Data
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        //save changings 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
