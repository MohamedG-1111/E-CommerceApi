using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>, new()
    {
        private readonly StoreDbContext dbContext;

        public GenericRepository(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(TEntity entity)=> await dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) =>  dbContext.Set<TEntity>().Remove(entity);
      

        public async Task<IEnumerable<TEntity>> GetAllAsync()=> await dbContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity?> GetByIdAsync(Tkey id) => await dbContext.Set<TEntity>().FindAsync(id);
      

        public void Update(TEntity entity)=> dbContext.Set<TEntity>().Update(entity);
        
    }
}
