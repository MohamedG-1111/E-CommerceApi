using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.Contracts;
using Shared.Dtos.BasketDTO;

namespace Presentation.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class BasketsController:ControllerBase
    {
        private readonly IBasketService basketService;

        public BasketsController(IBasketService basketService)
        {
            this.basketService = basketService;
        }

        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket(string Id)
        {
            var Basket=await  basketService.GetBasketAsync(Id);
            return Ok(Basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateBasket(BasketDto basketDto)
        {
            var Basket=await basketService.CreateOrUpdateServiceAsync(basketDto);   
            return Ok(Basket);
        }
        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string Id)
        {
            var result = await basketService.DeleteBasketAsync(Id);
            return Ok(result);  
        }
    }
}
