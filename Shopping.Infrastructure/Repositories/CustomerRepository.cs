using Castle.Core.Resource;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using Shopping.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shopping.Infrastructure.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ShoppingContext _shoppingContext;
        public CustomerRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public List<Customer> GetAllCustomers()
        {
            var records = _shoppingContext.Customers.Include(customer=>customer.Products).ToList();
            return records;
        }
        public Customer GetCustomerById(int customerId)
        {
            var customer = _shoppingContext.Customers.Where(customer => customer.CustomerId == customerId).Include(customer=>customer.Products).AsNoTracking().FirstOrDefault();
            return customer;
        }

        public Customer AddCustomer(string customerName)
        {
            var customer = new Customer(customerName);
            _shoppingContext.Customers.Add(customer);
            _shoppingContext.SaveChanges();
            return customer;
        }

        public Customer AddProductToCustomer(int customerId, string productName, double productPrice)
        {
            var customer = GetCustomerById(customerId);
            if (customer == null)
                return null;
            customer.AddProduct(productName,productPrice);
            _shoppingContext.Customers.Update(customer);
            _shoppingContext.SaveChanges();
            return customer;
        }

        public Customer GetCustomerByFilter(Expression<Func<Customer, bool>> predicate)
        {
            return _shoppingContext.Customers.Where(predicate).Include(customer => customer.Products).AsNoTracking().FirstOrDefault();
        }
    }
}
