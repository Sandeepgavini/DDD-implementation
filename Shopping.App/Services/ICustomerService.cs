using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public interface ICustomerService
    {
        Customer AddCustomer( CustomerDTO customer);
        CustomerDTO UpdateCustomerInfo(int customerId,CustomerDTO customer);
        bool DeleteCustomer(int customerId);
        Customer AddProductToCustomer(int customerId, ProductDTO product);
        List<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerDetails(string customerId);
    }
}