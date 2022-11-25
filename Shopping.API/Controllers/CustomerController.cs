using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.App.Services;
using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpGet("GetById/{customerId}")]
        public IActionResult GetCustomerById([FromRoute]int customerId)
        {
            var customer = _customerService.GetCustomerById(customerId);
            if(customer == null)
                return NotFound();
            return Ok(customer);
        }
        [HttpPost("{customerName}")]
        public IActionResult AddCustomer( [FromRoute]string customerName)
        {
            var customer = _customerService.AddCustomer( customerName);  
            return Ok(customer);
        }
        [HttpPost("{customerId}/{productName}/{productPrice}")]
        public IActionResult AddProductToCustomer([FromRoute]int customerId, [FromRoute] string productName,[FromRoute] double productPrice)
        {
            var customer = _customerService.AddProductToCustomer(customerId, productName,productPrice);
            if (customer == null)
                return BadRequest();
            return Ok(customer);
        }
    }
}
