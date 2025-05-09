using EcomProject.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Generic
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly EcommDBContext _ecommDBContext;

        public GenericRepo(EcommDBContext ecommDBContext)
        {
         _ecommDBContext = ecommDBContext;   
        }
        public void Add(T entity)
        {
            _ecommDBContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _ecommDBContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _ecommDBContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _ecommDBContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
