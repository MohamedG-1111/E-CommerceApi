using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity,bool>> Critria { get; }
        public ICollection<Expression<Func<TEntity, object>>> Includes { get; }

        public Expression<Func<TEntity,object>> OrderBy { get; }
        public Expression<Func<TEntity,object>> OrderByDsc { get; }

        public int Take { get; }
        public int Skip { get; }

        public bool IsPignate {  get; }
    }
}
