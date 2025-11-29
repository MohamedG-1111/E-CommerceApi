using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using E_Commerce.Services.Exceptions;
using Services.Abstractions.Contracts;
using Services.Specifications;
using Shared;
using Shared.Dtos;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
           var Brands= await unitOfWork.genericRepository<ProductBrand,int>().GetAllAsync();  
            return mapper.Map<IEnumerable<BrandDto>>(Brands);    
        }

        public async Task<PignatedPage<ProductDto>> GetAllProductsAsync(ParamaterQuery paramaters)
        {
            var Spc = new ProductTypeAndBrandSpecification(paramaters);
            var Products=await unitOfWork.genericRepository<Product,int>().GetAllAsync(Spc);
            var DataToReturned= mapper.Map<IEnumerable<ProductDto>>(Products);
            var CountSpec = new ProductCountSpecifications(paramaters);
            var CountOfProduct = await unitOfWork.genericRepository<Product, int>().GetProductCountAsync(CountSpec);
            var PageSize = DataToReturned.Count();
            return new PignatedPage<ProductDto>(paramaters.PageNumber,PageSize, CountOfProduct, DataToReturned);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            
            var Types = await unitOfWork.genericRepository<ProductType, int>().GetAllAsync();
            return mapper.Map<IEnumerable<TypeDto>>(Types);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var Spc = new ProductTypeAndBrandSpecification(id);

            var product = await unitOfWork.genericRepository<Product, int>().GetByIdAsync(Spc);
            if (product == null)
                throw new ProductNotFoundException(id);
            return mapper.Map<ProductDto>(product);
        }
     

    }
}
