using Microsoft.AspNetCore.Mvc;
using Shopping.App.Services;
using Shopping.Domain.Common;
using Shopping.Domain.DTO;
using Shopping.Domain.Entities;

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
            {
                return NotFound(Constant.NOUSER);
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


        [Route("{customerId}")]
        [HttpPost]
        public IActionResult AddProductToCustomer([FromRoute]int customerId, [FromBody] ProductDTO product)
        {
            var customer = _customerService.AddProductToCustomer(customerId, product);
            if (customer == null)
            {
                return BadRequest(Constant.NOUSER);
            }
            return Ok(customer);
        }

        [Route("Update/{customerId}")]
        [HttpPut]
        public IActionResult UpdateCustomerInfo([FromRoute] int customerId, [FromBody] CustomerDTO customer)
        {
            var newCustomer = _customerService.UpdateCustomerInfo(customerId, customer);
            return Ok(newCustomer);
        }

        [Route("Delete/{customerId}")]
        [HttpDelete]
        public IActionResult DeleteUserInfo([FromRoute] int customerId)
        {
            var isDeleted = _customerService.DeleteCustomer(customerId);
            if (!isDeleted)
            {
                return BadRequest(Constant.NOUSER);
            }
            return Ok();
        }
    }
}
