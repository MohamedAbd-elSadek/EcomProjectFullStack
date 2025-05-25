using EcomProject.DAL.Models;
using EcomProject.DAL.Repos.Basket;
using EcomProject.DAL.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public BasketsController(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> get(string id)
        {
            var result = await unitOfWork.customerBasket.GetBasketAsync(id);
            if (result is null) 
            {
                return Ok(new DAL.Models.CustomerBasket());
            }
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> Add([FromBody] DAL.Models.CustomerBasket basket)
        {
            var _basket = await unitOfWork.customerBasket.UpdateBasketAsync(basket);
            return Ok(_basket);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete (string id)
        {
            var result = await unitOfWork.customerBasket.DeleteBasketAsync(id);
            if (result)
            {
                return Ok();
            } 
            return BadRequest();     
        }
    }
}
