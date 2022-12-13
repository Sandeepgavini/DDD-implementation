using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.App.Services;
using Shopping.Domain.Entities;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAllProducts() {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet("{customerId}")]
        public IActionResult GetProduct([FromRoute]int customerId)
        {
            var product = _productService.GetProductsByCustomerId(customerId);
            return Ok(product);
        }
    }
}
