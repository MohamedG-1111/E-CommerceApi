using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.BasketModule;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
         Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket customerBasket,TimeSpan TimeToLive=default);
        Task<CustomerBasket?> GetCustomerBasket(string Key);

        Task<bool> DeleteCustomerBasket(string Key);

    }
}
