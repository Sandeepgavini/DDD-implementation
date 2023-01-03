using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shopping.Domain.Repository
{
    public interface ICustomerRepository
    {
         Customer AddCustomer( string customerName);
         Customer AddProductToCustomer(int customerId, string productName, double productPrice);
         List<Customer> GetAllCustomers();
         Customer GetCustomerById(int customerId);
         Customer GetCustomerByFilter(Expression<Func<Customer, bool>> predicate);
    }
}
