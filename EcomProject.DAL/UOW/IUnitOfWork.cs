using EcomProject.DAL.Repos.Basket;
using EcomProject.DAL.Repos.Category;
using EcomProject.DAL.Repos.Photo;
using EcomProject.DAL.Repos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.UOW
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        public ICategoryRepo CategoryRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IPhotoRepo PhotoRepo { get; }

        public ICustomerBasket customerBasket { get; }
    }
}
