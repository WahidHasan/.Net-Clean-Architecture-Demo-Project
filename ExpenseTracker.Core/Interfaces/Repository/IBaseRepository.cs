using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity: class
    {
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync<T>(T id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync();
        IQueryable<TEntity> GetAllQueryable();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdatePatchAsync();
        Task<bool> DeleteAsync(TEntity entity);
    }
}
