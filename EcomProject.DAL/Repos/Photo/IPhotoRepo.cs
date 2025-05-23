﻿using EcomProject.DAL.Repos.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.DAL.Repos.Photo
{
    public interface IPhotoRepo : IGenericRepo<Models.Photo>
    {
        void AddPhotoToProduct(Guid productId, Models.Photo photo);

        Task<List<Models.Photo>> GetPhotosFromProduct(Guid productId);

        void DeletePhotoFromProduct(Guid ProductId,Guid PhotoId);

        void DeleteAllPhotosFromProduct(Guid ProductId);
    }
}
