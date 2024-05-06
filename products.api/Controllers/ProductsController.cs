using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Interfaces;

namespace products.api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService){
            _productsService = productsService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productsService.GetAllProducts();
            return Ok(result);
        }
    }
}