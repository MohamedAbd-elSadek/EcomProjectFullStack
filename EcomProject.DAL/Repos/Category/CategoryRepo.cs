using EcomProject.DAL.Context;
using EcomProject.DAL.Repos.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Category
{
    public class CategoryRepo : GenericRepo<Models.Category> , ICategoryRepo
    {
        private readonly EcommDBContext _commDBContext;
        public CategoryRepo(EcommDBContext ecommDBContext) :base (ecommDBContext) 
        {
            _commDBContext = ecommDBContext;
        }
    }
}
