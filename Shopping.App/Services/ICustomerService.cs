using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public interface ICustomerService
    {
        Customer AddCustomer( string customerName);
        Customer AddProductToCustomer(int customerId, string productName, double productPrice);
        List<Customer> GetAllCustomers();
        Customer GetCustomerDetails(string customerId);
    }
}