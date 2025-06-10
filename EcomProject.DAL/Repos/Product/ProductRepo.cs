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
                .Include(p=>p.Photos)
                .FirstOrDefaultAsync(p=>p.ProductId == id);
        }

        // Sorting Section
        
        public async Task<List<Models.Product>> GetAllAsync(string sort, Guid? categoryId, int PageSize, int PageNumber, string? search)
        {
            var query =  _context.Products
                .Include(p=>p.Photos)
                .Include(p=>p.Category)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                var words = search.Split(' ');
                query = query.Where(p=> words.All(word => 
                p.Name.ToLower().Contains(word.ToLower())
                //||
                //p.Description.ToLower().Contains(word.ToLower())
                )   
                );
            }
            //Filtering By Category

            if (categoryId != null) 
            {
                query = query.Where(c => c.CategoryId == categoryId);
            }

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
            if (PageNumber<=0 )
            {
                PageNumber = 1;
            }
            if (PageSize<=0)
            {
                PageSize = 3;
            }
            
                query = query.Skip((PageSize) * (PageNumber - 1)).Take(PageSize);

            return (await query.ToListAsync());
        }

        public async Task<(List<Models.Product> Products, int TotalCount)> GetAllWithCountAsync(string sort, Guid? categoryId, int PageSize, int PageNumber, string? search)
        {
            var query = _context.Products
                .Include(p => p.Photos)
                .Include(p => p.Category)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(search))
            {
                var words = search.Split(' ');
                query = query.Where(p => words.All(word => p.Name.ToLower().Contains(word.ToLower())));
            }

            if (categoryId != null)
            {
                query = query.Where(c => c.CategoryId == categoryId);
            }

            var totalCount = await query.CountAsync();

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
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            if (PageNumber <= 0) PageNumber = 1;
            if (PageSize <= 0) PageSize = 3;

            var products = await query.Skip(PageSize * (PageNumber - 1)).Take(PageSize).ToListAsync();

            return (products, totalCount);
        }
    }
}
