using Microsoft.AspNetCore.Mvc;
using Shopping.App.Services;
using Shopping.Domain.Common;
using Shopping.Domain.DTO;

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

        [Route("{customerName}")]
        [HttpGet]
        public IActionResult GetCustomerDetails([FromRoute]string customerName,int customerId)
        {
            var customer = _customerService.GetCustomerDetails(customerName,customerId);
            if (customer == null)
            {
                return NotFound(Constants.NOUSER);
            }
            return Ok(customer);
        }

        [Route("AddUser")]
        [HttpPost]
        public IActionResult AddCustomer( [FromBody]CustomerDTO customer)
        {
            var newCustomer = _customerService.AddCustomer( customer);  
            return Ok(newCustomer);
        }


        [Route("AddProduct/{customerId}")]
        [HttpPost]
        public IActionResult AddProductToCustomer([FromRoute]int customerId, [FromBody] ProductDTO product)
        {
            var customer = _customerService.AddProductToCustomer(customerId, product);
            if (customer == null)
            {
                return BadRequest(Constants.NOUSER);
            }
            return Ok(customer);
        }

        [Route("Update/{customerId}")]
        [HttpPut]
        public IActionResult UpdateCustomerInfo([FromRoute] int customerId, [FromBody] CustomerDTO customer)
        {
            var newCustomer = _customerService.UpdateCustomerInfo(customerId, customer);
            if(newCustomer == null)
            {
                return BadRequest(Constants.NOUSER);
            }
            return Ok(newCustomer);
        }

        [Route("Delete/{customerId}")]
        [HttpDelete]
        public IActionResult DeleteUserInfo([FromRoute] int customerId)
        {
            var isDeleted = _customerService.DeleteCustomer(customerId);
            if (!isDeleted)
            {
                return BadRequest(Constants.NOUSER);
            }
            return Ok(Constants.DELETESUCESS);
        }
    }
}
