using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Dtos.BasketDTO;

namespace Services.Abstractions.Contracts
{
    public interface IBasketService
    {
        public Task<BasketDto> CreateOrUpdateServiceAsync(BasketDto basket);
        public Task<BasketDto?> GetBasketAsync(string Key);

        public Task<bool> DeleteBasketAsync(string Key);
    }
}
