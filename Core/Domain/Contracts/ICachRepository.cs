using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface ICachRepository
    {
    
        public Task<string?> GetAsync(string CachKey);

        public Task SetAsync(string CachKey, string Value,TimeSpan TimeToLive); 
    }
}
