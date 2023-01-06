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

        [Route("{productName}/GetProductInfo")]
        [HttpGet]
        public IActionResult GetProduct([FromRoute]string productName)
        {
            var product = _productService.GetProductDetails(productName);
            return product!=null ? Ok(product): BadRequest(Constants.NOPRODUCT);
        }

        [Route("AddProduct")]
        [HttpPost]
        public IActionResult AddNewProduct([FromBody] Product product)
        {
            var newProduct = _productService.AddNewProduct(product);
            return Ok(newProduct);
        }
    }
}
