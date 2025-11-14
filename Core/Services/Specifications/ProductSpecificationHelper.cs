using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ProductModule;
using Shared;

namespace Services.Specifications
{
    public static class ProductSpecificationHelper
    {
        public static Expression<Func<Product, bool>> GetProductCriteria(ParamaterQuery paramaters)
        {
            return (P => (!paramaters.BrandId.HasValue || P.BrandId == paramaters.BrandId)
        && (!paramaters.TypeId.HasValue || P.TypeId == paramaters.TypeId)
        && (String.IsNullOrEmpty(paramaters.Search) || P.Name.ToLower().Contains(paramaters.Search.ToLower())));
        }
    }
}
