using EcomProject.BL.DTOs.Category;
using EcomProject.BL.DTOs.Common;
using EcomProject.BL.Manager.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcomProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //All Endpoints Tested With Exception Handling
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        [HttpGet]

        public async Task<Ok<List<CategoryReadDTO>>> GetAllCategories()
        {
            return TypedResults.Ok(await categoryManager.GetAllCategories());
        }

        [HttpGet("{id}")]

        public async Task<Results<Ok<CategoryReadDTO>, NotFound>> GetCategoryById(Guid id)
        {
            var category = await categoryManager.GetCategory(id);
            if (category == null)
            {
                TypedResults.NotFound();
            }
            return TypedResults.Ok(category);
        }

        [HttpPost]
        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> AddCategory([FromBody] CategoryAddDTO category)
        {
            var result = await categoryManager.AddCategory(category);
            if (!result.IsValid)
            {
                return TypedResults.BadRequest(result);
            }
            return TypedResults.Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<Results<Ok<GeneralResult>, NotFound<GeneralResult>>> DeleteCategory(Guid id)
        {
            var result = await categoryManager.DeleteCategory(id);
            if (!result.IsValid)
            {
                return TypedResults.NotFound(result);
            }
            return TypedResults.Ok(result);
        }

        [HttpPut]
        public async Task<Results<Ok<GeneralResult>,BadRequest<GeneralResult>>> UpdateCategory([FromBody] CategoryUpdateDTO categoryUpd)
        {
            
            var result = await categoryManager.UpdateCategory(categoryUpd);
            if (!result.IsValid)
            {
                return TypedResults.BadRequest(result);
            }
            return TypedResults.Ok(result);
            }
    }
}
