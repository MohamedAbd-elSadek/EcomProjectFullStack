using EcomProject.BL.DTOs.Category;
using EcomProject.BL.DTOs.CetogoryValidator;
using EcomProject.BL.DTOs.Common;
using EcomProject.BL.Exceptions;
using EcomProject.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Category
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CategoryAddDTOValidator validations;
        private readonly CategoryUpdateDTOValidator validationsUpdate;

        public CategoryManager(IUnitOfWork unitOfWork
            ,CategoryAddDTOValidator validations
            ,CategoryUpdateDTOValidator updateValidator)
        {
            this.unitOfWork = unitOfWork;
            this.validations = validations;
            validationsUpdate = updateValidator;
        }
        public async Task<GeneralResult> AddCategory(CategoryAddDTO category)
        {
            var validationResult =await validations.ValidateAsync(category);
            if (!validationResult.IsValid) 
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors =validationResult.Errors.Select(e=>new Results
                    {
                        Message=e.ErrorMessage,
                        Code=e.ErrorCode,
                    }).ToArray()
                };
            }
            var newCategory = new DAL.Models.Category
            {
                CategoryId = Guid.NewGuid(),
                Name = category.Name,
                Description = category.Description,
            };
            unitOfWork.CategoryRepo.Add(newCategory);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResult
            {
                IsValid = true,
                Errors = []
            };
        }

        public async Task<GeneralResult> DeleteCategory(Guid id)
        {
            var category = await unitOfWork.CategoryRepo.GetAsync(id);
            if (category == null)
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors = new[]
                    {
                        new Results
                        {
                            Message = "Category Not Found",
                            Code="007"
                        }
                    }
                };
            }
            unitOfWork.CategoryRepo.Delete(category);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResult { IsValid = true , Errors = [] };  
        }

        public async Task<List<CategoryReadDTO>> GetAllCategories()
        {
            var categories = await unitOfWork.CategoryRepo.GetAllAsync();
            if (categories == null)
            {
                throw new Exception("Categories are Empty");
            }
            return categories.Select(c=> new CategoryReadDTO { 
                CategoryId = c.CategoryId,
                Name=c.Name,
                Description=c.Description}).ToList();
        }

        public async Task<CategoryReadDTO> GetCategory(Guid id)
        {
            var category = await unitOfWork.CategoryRepo.GetAsync(id);
            if (category == null)
            {
                throw new Exception("Category Not Found");
            }
            return new CategoryReadDTO
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };
        }

        public async Task<GeneralResult> UpdateCategory(CategoryUpdateDTO categoryUpdate)
        {
            var result = await validationsUpdate.ValidateAsync(categoryUpdate);
            if (!result.IsValid)
            {
                return new GeneralResult
                {
                    IsValid = false,
                    Errors = result.Errors.Select(e => new Results
                    {
                        Code = e.ErrorCode,
                        Message = e.ErrorMessage,
                    }).ToArray()
                };
            }
            var category = await unitOfWork.CategoryRepo.GetAsync(categoryUpdate.CategoryId);
            if (category == null)
            {
                throw new Exception("Category Not Found");
            }
            category.Name = categoryUpdate.Name;
            category.Description = categoryUpdate.Description;
            unitOfWork.CategoryRepo.Update(category);
            await unitOfWork.SaveChangesAsync();
            return new GeneralResult
            {
                IsValid = true,
                Errors = []
            };
        }
    }
}
