using EcomProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Basket
{
    public interface ICustomerBasket
    {
        Task<DAL.Models.CustomerBasket> GetBasketAsync(string id);

        Task<DAL.Models.CustomerBasket> UpdateBasketAsync(DAL.Models.CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string id); 
    }
}
