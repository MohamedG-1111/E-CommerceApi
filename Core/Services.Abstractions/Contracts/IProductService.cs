using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Shared.Dtos;

namespace Services.Abstractions.Contracts
{
    public interface IProductService
    {
         Task<PignatedPage<ProductDto>> GetAllProductsAsync(ParamaterQuery paramaters);
         Task<IEnumerable<TypeDto>> GetAllTypesAsync();
         Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        Task<ProductDto> GetProductByIdAsync(int id);

    }
}
