using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ProductModule;
using Shared;

namespace Services.Specifications
{
    public class ProductCountSpecifications : BaseSpecification<Product, int>
    {
        public ProductCountSpecifications(ParamaterQuery paramaters) : base(ProductSpecificationHelper.GetProductCriteria(paramaters))
        {
        }
    }
}
