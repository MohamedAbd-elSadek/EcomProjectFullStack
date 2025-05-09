using EcomProject.DAL.Context;
using EcomProject.DAL.Repos.Category;
using EcomProject.DAL.Repos.Photo;
using EcomProject.DAL.Repos.Product;
using EcomProject.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL
{
    public static class DataAccessExtensions
    {
        public static void AddDataAccessExtensions(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EcommDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IPhotoRepo, PhotoRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
