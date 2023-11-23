using CRUD_API.DbContexts;
using CRUD_API.IRepository;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Repository
{
    public class GetItemListWithCaching : ICaching
    {
        private readonly DbContextCom _context;
        private readonly IMemoryCache _cache;

        public GetItemListWithCaching(DbContextCom context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<object> GetAllItemList()
        {
            string cacheKey = "item";
            var data = new List<Models.Item>();

            bool isCached = _cache.TryGetValue(cacheKey, out data);

            if (!isCached)
            {
                data = (from i in _context.Items
                        where i.IsActive == true
                        select i).Take(50).ToList();
                var options = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(5),
                    SlidingExpiration = TimeSpan.FromHours(5)
                };

                _cache.Set(cacheKey, data, options  /*TimeSpan.FromHours(5) */);
            }

            return data;
        }
    }
}
