using EcomProject.DAL.Context;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommDBContext _context;
        public UnitOfWork(EcommDBContext context,
            ICategoryRepo categoryRepo,
            IProductRepo productRepo,
            IPhotoRepo photoRepo)
        {
            _context = context;
            categoryRepo = CategoryRepo;
            productRepo = ProductRepo;
            photoRepo = PhotoRepo;
        }

        public ICategoryRepo CategoryRepo { get; }
        public IProductRepo ProductRepo { get; }
        public IPhotoRepo PhotoRepo { get; }

        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
