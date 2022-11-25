using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using Shopping.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var records = _shoppingContext.Customers.ToList();
            return records;
        }
        public Customer GetCustomerById(int customerId)
        {
            var customer = _shoppingContext.Customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
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
            customer.AddProduct(productName,productPrice,customerId);
            var product = new Product(productName, productPrice, customerId);
            _shoppingContext.Products.Add(product);
            _shoppingContext.Customers.Update(customer);
            _shoppingContext.SaveChanges();
            return customer;
        }
    }
}
