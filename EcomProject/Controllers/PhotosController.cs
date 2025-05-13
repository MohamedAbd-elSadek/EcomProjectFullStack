using EcomProject.BL.DTOs.Photos;
using EcomProject.BL.Manager.Photo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EcomProject.Controllers
{
    [Route("api/Product/{productId}/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoManager photoManager;

        public PhotosController(IPhotoManager photoManager)
        {
            this.photoManager = photoManager;
        }
        [HttpGet]
        public async Task<Results<Ok<List<ReadPhotoDTO>>,BadRequest>> GetAllPhotos(Guid productId)
        {
            var photos = await photoManager.GetAllPhotosFromProduct(productId);
            if (photos == null)
            {
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(photos);
        }

        [HttpPost]

        public async Task<IActionResult> AddPhotoToProduct(Guid productId,IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest(new { message = "No file uploaded." });

                // Generate unique filename
                var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";

                // Save to server
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Attachments");
                Directory.CreateDirectory(uploadsFolder);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Generate accessible URL
                var fileUrl = $"{Request.Scheme}://{Request.Host}/attachments/{uniqueFileName}";

                // Save to database
                await photoManager.AddPhotoToProduct(
                    productId,
                    new AddPhotoDTO
                    {
                        PhotoName = file.FileName,
                        PhotoPath = fileUrl
                    }
                );

                // Return URL in response
                return Ok(new
                {
                    IsSuccess = true,
                    FileUrl = fileUrl,
                    FileName = file.FileName
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{photoId}")]

        public async Task<IActionResult> DeletePhotoFromProduct(Guid productId,Guid photoId)
        {
            try
            {
                // Verify attachment belongs to bug
                var photo = await photoManager.GetPhotoByIdAsync(photoId);
                if (photo == null)
                {
                    return NotFound(new { message = "Photo not found for this product" });
                }

                await photoManager.RemovePhotosFromProduct(photoId);
                return Ok(new { message = "Photo deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
     }
}
