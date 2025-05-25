using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Basket
{
    public class CustomerBasket : ICustomerBasket
    {
        private readonly IDatabase _database;
      
        public CustomerBasket(IConnectionMultiplexer redis)
        {
            _database=redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await _database.KeyDeleteAsync(id);
        }

        public async Task<DAL.Models.CustomerBasket> GetBasketAsync(string id)
        {
            var result = await _database.StringGetAsync(id);
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }
            else return JsonSerializer.Deserialize<DAL.Models.CustomerBasket>(result);
            
        }

        public async Task<DAL.Models.CustomerBasket> UpdateBasketAsync(DAL.Models.CustomerBasket basket)
        {
            var _basket = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(3));
            if (_basket != null) {
             return await GetBasketAsync(basket.Id);   
            }
            return null;
        }
    }
}
