using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using System;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public class CustomerService : ICustomerService
    {
        private  ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }
        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.GetCustomerById(customerId);
       
        }
        public Customer AddCustomer( string customerName)
        {
            return _customerRepository.AddCustomer(customerName);
        }

        public Customer AddProductToCustomer(int customerId, string productName, double productPrice)
        {
            return _customerRepository.AddProductToCustomer(customerId, productName,productPrice);
            
        }
    }
}
