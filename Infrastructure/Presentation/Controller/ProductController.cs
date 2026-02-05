using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Presentation.Attributes;
using Services.Abstractions.Contracts;
using Shared;
using Shared.Dtos;

namespace Presentation.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("Products")]
        [RedisCach]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery] ParamaterQuery paramaters) => Ok(await (productService.GetAllProductsAsync(paramaters)));
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands() => Ok(await (productService.GetAllBrandsAsync()));
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes() => Ok(await (productService.GetAllTypesAsync()));

        [HttpGet("Products/{id:int}")]

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProduct(int id)
        {
           return Ok(await (productService.GetProductByIdAsync(id)));
        }


    }
}
