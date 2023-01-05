using Microsoft.AspNetCore.Mvc;
using Shopping.App.Services;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [Route("{customerIdentifier}")]
        [HttpGet]
        public IActionResult GetCustomerDetails([FromRoute] string customerIdentifier)
        {
            var customer = _customerService.GetCustomerDetails(customerIdentifier);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [Route("{customerName}")]
        [HttpPost]
        public IActionResult AddCustomer( [FromRoute]string customerName)
        {
            var customer = _customerService.AddCustomer( customerName);  
            return Ok(customer);
        }

        [Route("{customerId}/{productName}/{productPrice}")]
        [HttpPost]
        public IActionResult AddProductToCustomer([FromRoute]int customerId, [FromRoute] string productName,[FromRoute] double productPrice)
        {
            var customer = _customerService.AddProductToCustomer(customerId, productName,productPrice);
            if (customer == null)
                return BadRequest();
            return Ok(customer);
        }
       
    }
}
