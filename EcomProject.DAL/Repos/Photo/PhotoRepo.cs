using EcomProject.DAL.Context;
using EcomProject.DAL.Models;
using EcomProject.DAL.Repos.Generic;
using Microsoft.EntityFrameworkCore;
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

        public void AddPhotoToProduct(Guid productId, Models.Photo photo)
        {
            
            //photo.ProductId = productId;
            _context.Photos.Add(photo);
            Console.WriteLine("Saving Photo with ProductId: " + photo.ProductId);

        }

        public void DeleteAllPhotosFromProduct(Guid productId)
        {
            var photos = _context.Photos
                .Where(p=> p.ProductId == productId)
                .ToList();
            if (!photos.Any())
            {
                throw new Exception("Product Was Not Found");
            }
            _context.Photos.RemoveRange(photos);
                
                
        }

        public void DeletePhotoFromProduct(Guid ProductId, Guid PhotoId)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.PhotoId == PhotoId && p.ProductId == ProductId);
            if (photo == null)
            {
                throw new Exception("Photo was not Found");
            }
            _context.Photos.Remove(photo);
        }

        public Task<List<Models.Photo>> GetPhotosFromProduct(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(p=>p.ProductId == productId);
            if (product == null)
            {
                throw new Exception("Product Was Not Found");
            }
            return _context.Photos.Where(e=>e.ProductId == productId).Include(e=>e.Product).ToListAsync();
        }


    }
}
