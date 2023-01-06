using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Shopping.Domain.Repository
{
    public interface ICustomerRepository
    {
         Customer AddCustomer(Customer customer);
         Customer UpdateCustomerInfo(int customerId,Customer customerInfo);
         bool DeleteCustomer(int customerId);
         List<Customer> GetAllCustomers();
         Customer GetCustomerById(int customerId);
         Customer GetCustomerByFilter(Expression<Func<Customer, bool>> predicate);
    }
}
