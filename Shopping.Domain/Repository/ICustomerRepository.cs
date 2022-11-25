using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.Domain.Repository
{
    public interface ICustomerRepository
    {
         Customer AddCustomer( string customerName);
         Customer AddProductToCustomer(int customerId, string productName, double productPrice);
         List<Customer> GetAllCustomers();
         Customer GetCustomerById(int customerId);
    }
}
