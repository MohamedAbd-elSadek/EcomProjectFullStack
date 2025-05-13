using FluentValidation;
using EcomProject.BL.Manager.Category;
using EcomProject.BL.Manager.Photo;
using EcomProject.BL.Manager.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL
{
    public static class BusinessExtensions
    {
        public static void AddBussinessExtensions(IServiceCollection services)
        {
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IPhotoManager, PhotoManager>();

            services.AddValidatorsFromAssembly(typeof(BusinessExtensions).Assembly);
        }
         
    }
}
