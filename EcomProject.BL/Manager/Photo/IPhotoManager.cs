using EcomProject.BL.DTOs.Photos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Photo
{
    public interface IPhotoManager
    {
        Task RemovePhotosFromProduct(Guid productId);

        Task AddPhotoToProduct(Guid productId, AddPhotoDTO addPhotoDTO);

        Task<List<ReadPhotoDTO>> GetAllPhotosFromProduct(Guid productId);

        Task<ReadPhotoDTO> GetPhotoByIdAsync(Guid id);
    }
}
