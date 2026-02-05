using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;

namespace Services.Specifications
{
    public abstract class BaseSpecification<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        public ICollection<Expression<Func<TEntity, object>>> Includes { get; } = [];

        public Expression<Func<TEntity, bool>> Critria { get; }

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDsc { get; private set; }

        public int Take {  get;private set; }

        public int Skip {  get;private set; }

        public bool IsPignate { get; private set; }

        public BaseSpecification(Expression<Func<TEntity,bool>> Cretria)
        {
            this.Critria = Cretria;
        }
        public void AddPignate(int PageSize,int PageNumber)
        {
            Take=PageSize;
            Skip=(PageNumber-1)*PageSize;
            IsPignate = true;
        }

        protected void AddIncludes(Expression<Func<TEntity, object>> include)
        {
            Includes.Add(include);
        }
        protected void AddOrderBy(Expression<Func<TEntity, object>> Orderexpression)
        {
            this.OrderBy = Orderexpression;
        }

        protected void AddOrderByDsc(Expression<Func<TEntity, object>> Orderexpression)
        {
            this.OrderByDsc = Orderexpression;
        }
    }
}
