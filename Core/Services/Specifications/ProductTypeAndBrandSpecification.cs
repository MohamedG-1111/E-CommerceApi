using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.ProductModule;
using Shared;

namespace Services.Specifications
{
    public class ProductTypeAndBrandSpecification:BaseSpecification<Product,int>
    {
        public ProductTypeAndBrandSpecification(ParamaterQuery paramaters) : base(ProductSpecificationHelper.GetProductCriteria(paramaters))
        {
            AddIncludes(P => P.ProductType);
            AddIncludes(P => P.ProductBrand);


            switch (paramaters.Sort)
            {
                case ProductSorting.Name:
                    AddOrderBy(p=>p.Name);
                    break;
                case ProductSorting.NameDsc:
                    AddOrderByDsc(P=>P.Name);
                    break;
                case ProductSorting.Price:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSorting.PriceDsc:
                    AddOrderByDsc(P => P.Price);
                    break;
                default:
                    AddOrderBy(P=>P.Id);
                    break;
            }

            AddPignate(paramaters.PageSize, paramaters.PageNumber);
        }
        public ProductTypeAndBrandSpecification(int id) : base(p => p.Id==id)
        {
            AddIncludes(P => P.ProductType);
            AddIncludes(P => P.ProductBrand);
        }
    }
}
