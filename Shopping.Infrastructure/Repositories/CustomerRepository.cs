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
            var customer = _shoppingContext.Customers.Where(customer => customer.CustomerId == customerId).Include(customer=>customer.Products).FirstOrDefault();
            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            _shoppingContext.Customers.Add(customer);
            _shoppingContext.SaveChanges();
            return customer;
        }

        public Customer AddProductToCustomer(int customerId, Product product)
        {
            var customer = GetCustomerById(customerId);
            customer.AddProductsToList(product);
            _shoppingContext.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomerInfo(int customerId, Customer customerInfo)
        {
            var customer = GetCustomerById(customerId);
            customer.CustomerNumber = customerInfo.CustomerNumber;
            _shoppingContext.SaveChanges();
            return customer;
        }

        public bool DeleteCustomer(int customerId)
        {
            var customer = GetCustomerById(customerId);
            if(customer != null)
            {
                _shoppingContext.Customers.Remove(customer);
                _shoppingContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Customer GetCustomerByFilter(Expression<Func<Customer, bool>> predicate)
        {
            return _shoppingContext.Customers.Where(predicate).Include(customer => customer.Products).FirstOrDefault();
        }
    }
}
