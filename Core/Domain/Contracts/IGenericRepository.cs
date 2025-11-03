using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>,new()
    {
        // Add
        Task AddAsync(TEntity entity);

        // GetAll
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(TKey id);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
