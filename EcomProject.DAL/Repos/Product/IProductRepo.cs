using EcomProject.DAL.Repos.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Product
{
    public interface IProductRepo : IGenericRepo<Models.Product>
    {
        Task<List<Models.Product>> GetAllWithCategoryAsync();
        Task<Models.Product?> GetByIdWithCategoryAsync(Guid id);
        Task<List<Models.Product>> GetAllAsync(string sort);
    }
}
