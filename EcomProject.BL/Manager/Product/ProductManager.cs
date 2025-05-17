using EcomProject.BL.DTOs.Common;
using EcomProject.BL.DTOs.Product;
using EcomProject.BL.DTOs.ProductValidator;
using EcomProject.DAL.Models;
using EcomProject.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Product
{
    public class ProductManager : IProductManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ProductAddDTOValidator validationAdd;
        private readonly ProductUpdateDTOValidator validationUpdate;

        public ProductManager(IUnitOfWork unitOfWork,
            ProductAddDTOValidator validationAdd
            ,ProductUpdateDTOValidator validationUpdate)
        {
            this.unitOfWork = unitOfWork;
            this.validationAdd = validationAdd;
            this.validationUpdate = validationUpdate;
        }
        public async Task<GeneralResult> AddProduct(ProductAddDTO productAddDTO)
        {
            var validationResult = await validationAdd.ValidateAsync(productAddDTO);
            if (!validationResult.IsValid)
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors = validationResult.Errors.Select(e => new Results
                    {
                        Message = e.ErrorMessage,
                        Code = e.ErrorCode
                    }).ToArray()
                };
            }
            var newProdcut = new DAL.Models.Product
            {
                ProductId = Guid.NewGuid(),
                Name = productAddDTO.Name,
                Description = productAddDTO.Description,
                Price = productAddDTO.Price,
                Discount = productAddDTO.Discount,
                ManufactureDate = productAddDTO.ManufactureDate,
                CategoryId = productAddDTO.CategoryId,
            };
            unitOfWork.ProductRepo.Add(newProdcut);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResult
            {
                IsValid = true,
                Errors = []

            };
        }

        public async Task<GeneralResult> DeleteProduct(Guid productId)
        {
            var product = await unitOfWork.ProductRepo.GetAsync(productId);
            if (product == null)
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors = new[] {
                        new Results
                    {
                        Message = "Product was Not Found",
                        Code="007"
                    }
                    }
                };
            }
            unitOfWork.ProductRepo.Delete(product);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResult
            {
                IsValid = true,
                Errors = []
            };
        }

        public async Task<List<ProductReadDTO>> GetAllProducts()
        {
            var products = await unitOfWork.ProductRepo.GetAllWithCategoryAsync();
            if (products == null)
            {
                throw new Exception("No Products were Found");
            }
            return products.Select(p => new ProductReadDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                ManufactureDate = p.ManufactureDate,
                Price = p.Price,
                Discount = p.Discount,
                CategoryName = p.Category?.Name ?? "No Category",
                Photos = p.Photos.Select(photo => new DTOs.Photos.ReadPhotoDTO
                {
                    PhotoId = photo.PhotoId,
                    PhotoPath = photo.PhotoPath,
                    ProductId=photo.ProductId
                }).ToList(),

            }).ToList();

            //عرفت الغلطة فين يس ههههههههههييييييييييييييييييهههههههههههههه يلا امعلم صلح ووريني دخيلك معليييم
        }

        public async Task<List<ProductReadDTO>> GetAllProducts(string sort, Guid? categoryId, int PageSize, int PageNumber, string? search)
        {
            if (string.IsNullOrWhiteSpace(sort))
            {
            sort = "NameAsc";
            }
            var products = await unitOfWork.ProductRepo.GetAllAsync(sort,categoryId,  PageSize,  PageNumber,search);
            if (products == null)
            {
                    return new List<ProductReadDTO>(); 
            }
            return products.Select(p => new ProductReadDTO
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Description = p.Description,
                ManufactureDate = p.ManufactureDate,
                Price = p.Price,
                Discount = p.Discount,
                CategoryName = p.Category?.Name ?? "No Category",
                Photos = p.Photos.Select(photo => new DTOs.Photos.ReadPhotoDTO
                {
                    PhotoId = photo.PhotoId,
                    PhotoPath = photo.PhotoPath,
                    ProductId = photo.ProductId
                }).ToList(),
            }).ToList();

            //عرفت الغلطة فين يس ههههههههههييييييييييييييييييهههههههههههههه يلا امعلم صلح ووريني دخيلك معليييم
        }

        public async Task<ProductReadDTO> GetProductById(Guid productId)
        {
            var product = await unitOfWork.ProductRepo.GetByIdWithCategoryAsync(productId);
            if (product == null)
            {
                throw new Exception("Product Was Not Found");
            }
            return new ProductReadDTO { 
                ProductId=productId,
                Name = product.Name,
                Description = product.Description,
                ManufactureDate = product.ManufactureDate,
                Price = product.Price,
                Discount = product.Discount,
                CategoryName = product.Category.Name,
                Photos = product.Photos.Select(photo => new DTOs.Photos.ReadPhotoDTO
                {
                    PhotoId = photo.PhotoId,
                    PhotoPath = photo.PhotoPath,
                    ProductId = photo.ProductId
                }).ToList(),
            };
        }

        public async Task<GeneralResult> UpdateProduct(ProductUpdateDTO updateDTO)
        {
            var validationResult = await validationUpdate.ValidateAsync(updateDTO);
            if (!validationResult.IsValid)
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors = validationResult.Errors.Select(e => new Results
                    {
                        Message = e.ErrorMessage,
                        Code = e.ErrorCode
                    }).ToArray()
                };
            }
            var product = await unitOfWork.ProductRepo.GetByIdWithCategoryAsync(updateDTO.ProductId);
            if (product == null)
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors = new[] { 
                        new Results
                    {
                        Message = "Product was Not Found",
                        Code="007"
                    }
                    }
                };
            }
            product.Name = updateDTO.Name;
            product.Description = updateDTO.Description;
            product.Price = updateDTO.Price;
            product.Discount = updateDTO.Discount;
            product.ManufactureDate = updateDTO.ManufactureDate;
            product.CategoryId = updateDTO.CategoryId;
            unitOfWork.ProductRepo.Update(product);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResult
            {
                IsValid = true,
                Errors = []
            };
        }
    }
}
