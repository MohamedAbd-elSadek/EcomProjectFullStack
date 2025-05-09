using EcomProject.DAL.Context;
using EcomProject.DAL.Repos.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Photo
{
    public class PhotoRepo : GenericRepo<Models.Photo>, IPhotoRepo
    {
        private readonly EcommDBContext _context;
        public PhotoRepo(EcommDBContext ecommDBContext) : base(ecommDBContext)
        {
            _context = ecommDBContext;
        }
    }
}
