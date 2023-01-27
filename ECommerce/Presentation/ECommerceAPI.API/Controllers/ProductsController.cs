using ECommerceAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        //Burada interface istedik fakat bize Ioc Containerdan Persistencetaki interfacein karsiligi olan concrete nesne gelecektir
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {

            var products = _productService.GetProducts();
            return Ok(products);
        }
    }
}
