using EcomProject.DAL.Context;
using EcomProject.DAL.Models;
using EcomProject.DAL.Repos.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Product
{
    public class ProductRepo : GenericRepo<Models.Product>, IProductRepo
    {
        private readonly EcommDBContext _context;
        public ProductRepo(EcommDBContext ecommDBContext) : base(ecommDBContext)
        {
            _context = ecommDBContext;
        }

        public async Task<List<Models.Product>> GetAllWithCategoryAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .ToListAsync();
            
        }

        public async Task<Models.Product?> GetByIdWithCategoryAsync(Guid id)
        {
           return await _context.Products
                .Include (p => p.Category)
                .FirstOrDefaultAsync(p=>p.ProductId == id);
        }

        // Sorting Section

        public async Task<List<Models.Product>> GetAllAsync(string sort)
        {
            var query =  _context.Products
                .Include(p=>p.Photos)
                .Include(p=>p.Category)
                .AsNoTracking();

            if (string.IsNullOrEmpty(sort))
            {
                sort = "NameAsc";
            }
            switch (sort.ToLower())
            {
                case "priceasc":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "pricedesc":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                case "nameasc":
                default:
                    query=query.OrderBy(p => p.Name);
                    break;

            }
            return (await query.ToListAsync());
        }
    }
}
