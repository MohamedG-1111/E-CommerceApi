using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Contracts;
using Domain.Entities.BasketModule;
using Services.Abstractions.Contracts;
using Shared.Dtos.BasketDTO;

namespace Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public BasketService(IBasketRepository basketRepository,IMapper mapper)
        {
            this.basketRepository = basketRepository;
            this.mapper = mapper;
        }
        public async Task<BasketDto> CreateOrUpdateServiceAsync(BasketDto basket)
        {
            var Basket = mapper.Map<CustomerBasket>(basket);
            var CreatedBasket = await basketRepository.CreateOrUpdateBasketAsync(Basket);
            return mapper.Map<CustomerBasket, BasketDto>(CreatedBasket);
        }

        public async Task<bool> DeleteBasketAsync(string Key)
        {
            return await basketRepository.DeleteCustomerBasket(Key);
        }

        public async Task<BasketDto?> GetBasketAsync(string Key)
        {
            var basket = await basketRepository.GetCustomerBasket(Key);

            if (basket is null)
                return null;

            return mapper.Map<BasketDto>(basket);
        }
    }
}
