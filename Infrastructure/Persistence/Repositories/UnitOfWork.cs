using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext dbContext;
        private readonly ConcurrentDictionary<string, Object> Respotories;

        public UnitOfWork(StoreDbContext dbContext)
        {
            this.dbContext = dbContext;
            Respotories=new ConcurrentDictionary<string, Object>();
        }
        public IGenericRepository<TEntity, TKey> genericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>, new()
        => (IGenericRepository<TEntity, TKey>)Respotories.GetOrAdd(typeof(TEntity).Name,
            (_)=>new GenericRepository<TEntity,TKey>(dbContext));
            //var dictKey=typeof(TEntity).Name;
            //if(!Respotories.ContainsKey(dictKey))
            //{
            //    Respotories.Add(dictKey , new GenericRepository<TEntity, TKey>(dbContext)); 
            //}
            //return (IGenericRepository<TEntity, TKey>)Respotories[dictKey];

        

        public Task<int> SaveChangesAsync()=>dbContext.SaveChangesAsync();
        
    }
}
