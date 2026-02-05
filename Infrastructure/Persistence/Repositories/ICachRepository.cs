using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Persistence.Repositories
{
    public class CachRepository:ICachRepository
    {
        public IDatabase database;
        public CachRepository(IConnectionMultiplexer connection)
        {
            database = connection.GetDatabase();
        }
        public async Task<string?> GetAsync(string CachKey)
        {
           var CachValue=await database.StringGetAsync(CachKey);
            return CachValue.IsNullOrEmpty ? null : CachValue.ToString();
        }

        public async Task SetAsync(string CachKey, string Value,TimeSpan TimeToLive)
        {
           await database.StringSetAsync(CachKey, Value, TimeToLive);    
        }
    }
}
