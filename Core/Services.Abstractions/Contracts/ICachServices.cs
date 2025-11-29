using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Contracts
{
    public interface ICachServices
    {
        public Task SetAsync(string CachKey,object CachValue,TimeSpan TimeToLive);

        public Task<string?> GetAsync(string CachKey);
    }
}
