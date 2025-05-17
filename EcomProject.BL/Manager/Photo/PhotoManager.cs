using EcomProject.BL.DTOs.Photos;
using EcomProject.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Photo
{
    public class PhotoManager : IPhotoManager
    {
        private readonly IUnitOfWork unitOfWork;

        public PhotoManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddPhotoToProduct(Guid productId, AddPhotoDTO addPhotoDTO)
        {
            var prodcut = await unitOfWork.ProductRepo.GetAsync(productId);
            if (prodcut == null)
            {
                throw new Exception("Product was not found");
            }
            var newPhoto = new DAL.Models.Photo
            {
                PhotoId= Guid.NewGuid(),
                PhotoPath = addPhotoDTO.PhotoPath,
                ProductId= productId,
                PhotoName = Path.GetFileName(addPhotoDTO.PhotoPath) // ✅ Fix: required field
            };
            unitOfWork.PhotoRepo.AddPhotoToProduct(productId, newPhoto);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ReadPhotoDTO>> GetAllPhotosFromProduct(Guid productId)
        {
            var product = await unitOfWork.ProductRepo.GetAsync(productId);
            if(product == null)
            {
                throw new Exception("Product was not Found");
            }
            var photos = await unitOfWork.PhotoRepo.GetPhotosFromProduct(productId);
            return photos.Select(p=> new ReadPhotoDTO 
            { PhotoId = p.PhotoId,
                PhotoPath = p.PhotoPath,
                ProductId= p.ProductId,
                //ProductName = p.Product.Name
            }
            ).ToList();
        }

        public async Task RemovePhotosFromProduct(Guid productId)
        {
            var product = await unitOfWork.ProductRepo.GetAsync(productId);
            if (product == null)
            {
                throw new Exception("Product was not Found");
            }
            unitOfWork.PhotoRepo.DeleteAllPhotosFromProduct(productId);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task<ReadPhotoDTO> GetPhotoByIdAsync(Guid id)
        {
            var photo = await unitOfWork.PhotoRepo.GetAsync(id);
            if (photo == null)
            {
                throw new Exception("Photo not found");
            }
            return new ReadPhotoDTO
            {
                PhotoId = photo.PhotoId,
                PhotoPath = photo.PhotoPath,
                ProductId=photo.ProductId
            };

        }
    }
}
