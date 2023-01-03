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

        public Customer GetCustomerDetails(string customerIdentifier)
        {
            try
            {
                int customerId = int.Parse(customerIdentifier);
                return _customerRepository.GetCustomerByFilter(x=>x.CustomerId == customerId);
            }
            catch(Exception e)
            {
                return _customerRepository.GetCustomerByFilter(x => x.CustomerName == customerIdentifier);
            }
            
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
