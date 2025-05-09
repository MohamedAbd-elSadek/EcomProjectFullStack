using EcomProject.DAL.Context;
using EcomProject.DAL.Repos.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Product
{
    public class ProductRepo : GenericRepo<Models.Product>, IProductRepo
    {
        public ProductRepo(EcommDBContext ecommDBContext) : base(ecommDBContext)
        {
        }
    }
}
