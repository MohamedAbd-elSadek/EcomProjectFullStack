using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Generic
{
    public interface IGenericRepo<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> GetAsync(Guid id);

        Task<List<T>> GetAllAsync();
    }
}
