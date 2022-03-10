using ExpenseTracker.Core.Interfaces;
using ExpenseTracker.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync<T>(T id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            //_context.Set<TEntity>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdatePatchAsync()
        {
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
             _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        //public Task<TEntity> GetByIdAsync<T>(T id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
