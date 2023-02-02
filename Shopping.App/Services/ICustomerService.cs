using Castle.Core.Resource;
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
        List<CustomerDTO> GetAllCustomers();
        Customer GetCustomerDetails(string customerName,int customerId);
    }
}