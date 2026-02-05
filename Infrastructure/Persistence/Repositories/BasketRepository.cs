using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities.BasketModule;
using StackExchange.Redis;

namespace Persistence.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase DataBase;

        public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            DataBase= connectionMultiplexer.GetDatabase();
        }
        public async Task<CustomerBasket> CreateOrUpdateBasketAsync(CustomerBasket customerBasket, TimeSpan TimeToLive = default)
        {
            var Value=JsonSerializer.Serialize(customerBasket);
           var Created= await DataBase.StringSetAsync(customerBasket.Id, Value, (TimeToLive == default) ? TimeSpan.FromDays(7) : TimeToLive);
            if (!Created) 
                return null;
            else 
                return await GetCustomerBasket(customerBasket.Id);
        }

        public Task<bool> DeleteCustomerBasket(string Key)=>DataBase.KeyDeleteAsync(Key);
        
           

        public async Task<CustomerBasket?> GetCustomerBasket(string Key)
        {
            var valueRedis = await DataBase.StringGetAsync(Key);
            if (valueRedis.IsNullOrEmpty) return null;

            var value = JsonSerializer.Deserialize<CustomerBasket>(valueRedis!);
            if (value is null) return null;

            return value;

        }
    }
}
