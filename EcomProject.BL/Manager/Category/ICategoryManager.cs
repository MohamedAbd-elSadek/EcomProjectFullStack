using EcomProject.BL.DTOs.Category;
using EcomProject.BL.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomProject.BL.Manager.Category
{
    public interface ICategoryManager
    {
        Task<CategoryReadDTO> GetCategory(Guid id);
        Task<List<CategoryReadDTO>> GetAllCategories();

        Task<GeneralResult> AddCategory(CategoryAddDTO category);
        Task<GeneralResult> DeleteCategory(Guid id);
        Task<GeneralResult> UpdateCategory(CategoryUpdateDTO category);
    }
}
