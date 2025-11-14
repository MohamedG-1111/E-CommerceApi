using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
            IQueryable<TEntity> entryPoint,
            ISpecifications<TEntity, TKey> specifications)
            where TEntity : BaseEntity<TKey>
        {
            var Query = entryPoint;

            if (specifications is not null)
            {
                if (specifications.Critria is not null)
                {
                    Query = Query.Where(specifications.Critria);
                }

                if (specifications.OrderBy is not null)
                {
                    Query = Query.OrderBy(specifications.OrderBy);
                }

                if (specifications.OrderByDsc is not null)
                {
                    Query = Query.OrderByDescending(specifications.OrderByDsc);
                }

                if (specifications.Includes is not null && specifications.Includes.Any())
                {
                    foreach (var specificationInclude in specifications.Includes)
                    {
                        Query = Query.Include(specificationInclude);
                    }
                }
                if (specifications.IsPignate)
                {
                    Query = Query.Skip(specifications.Skip).Take(specifications.Take);
                }
            }

            return Query.AsQueryable();
        }
    }
}
