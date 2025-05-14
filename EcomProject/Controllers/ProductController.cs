using EcomProject.BL.DTOs.Common;
using EcomProject.BL.DTOs.Product;
using EcomProject.BL.Manager.Product;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcomProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;

        public ProductController(IProductManager productManager)
        {
            this.productManager = productManager;
        }

        [HttpGet]

        public async Task<Ok<List<ProductReadDTO>>> GetAllProducts(string? sort,Guid? categoryId,int PageSize,int PageNumber,string? search)
        {
            return TypedResults.Ok(await productManager.GetAllProducts(sort,categoryId,  PageSize,  PageNumber,search));
        }

        [HttpGet("{id}")]
        public async Task<Results<Ok<ProductReadDTO>,NotFound>> GetProductById(Guid id)
        {
            var product = await productManager.GetProductById(id);
            if (product == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(product);
        }

        [HttpPost]

        public async Task<Results<Ok<GeneralResult>,BadRequest<GeneralResult>>> AddProduct([FromBody]ProductAddDTO productAddDTO)
        {
            var result = await productManager.AddProduct(productAddDTO);
            if (result.IsValid)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.BadRequest(result);
        }

        [HttpDelete("{id}")]

        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> DeleteProduct(Guid id)
        {
            
            var result = await productManager.DeleteProduct(id);
            if (result.IsValid)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.BadRequest(result);
        }

        [HttpPut]

        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> UpdateProduct([FromBody] ProductUpdateDTO productUpdateDTO)
        {
           
            var result = await productManager.UpdateProduct(productUpdateDTO);
            if (result.IsValid)
            {
                return TypedResults.Ok(result);
            }
            return TypedResults.BadRequest(result);
        }
    }
}
