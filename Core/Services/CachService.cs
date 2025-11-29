using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Persistence.Repositories;
using Services.Abstractions.Contracts;

namespace Services
{
    public class CachService : ICachServices
    {
        private readonly ICachRepository cachServices;

        public CachService(ICachRepository cachServices)
        {
            this.cachServices = cachServices;
        }
        public async Task<string?> GetAsync(string CachKey)
        {
          return   await cachServices.GetAsync(CachKey);
        }

        public async Task SetAsync(string CachKey, object CachValue, TimeSpan TimeToLive)
        {
            var Value = JsonSerializer.Serialize(CachValue);
            await cachServices.SetAsync(CachKey, Value, TimeToLive);
        }
    }
}
