using Shopping.Domain.DTO;
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

        public List<CustomerDTO> GetAllCustomers()
        {
            return MapCustomersToDTO(_customerRepository.GetAllCustomers());
        }

        public CustomerDTO GetCustomerDetails(string customerName ,int customerId=0)
        {
                return MapCustomerToDTO(_customerRepository.GetCustomerByFilter(x=>x.CustomerId == customerId ||x.CustomerName == customerName));
        }
        
        public Customer AddCustomer(CustomerDTO customer)
        {
            return _customerRepository.AddCustomer(MapDTOToCustomer(customer));
        }

        public CustomerDTO UpdateCustomerInfo(int customerId,CustomerDTO customer)
        {
            return MapCustomerToDTO(_customerRepository.UpdateCustomerInfo(customerId,MapDTOToCustomer(customer)));
        }
        
        public bool DeleteCustomer(int customerId)
        {
            return _customerRepository.DeleteCustomer(customerId);
        }

        public Customer AddProductToCustomer(int customerId, ProductDTO product)
        {
            return _customerRepository.AddProductToCustomer(customerId, MapDTOToProduct(product));
        }

        public Product MapDTOToProduct(ProductDTO productDto)
        {
            var product = new Product(productDto.ProductName, productDto.ProductPrice);
            return product;
        }

        public Customer MapDTOToCustomer(CustomerDTO customerDto)
        {
            var customer = new Customer(customerDto.CustomerName,customerDto.CustomerNumber);
            return customer;
        }

        public List<CustomerDTO> MapCustomersToDTO(List<Customer> customers)
        {
            var customerDtos = new List<CustomerDTO>();
            foreach(var customer in customers)
            {
                var customerDto = new CustomerDTO(customer.CustomerId, customer.CustomerName,customer.CustomerNumber, customer.TotalBill);
                customerDtos.Add(customerDto);
            }
            return customerDtos;
        }

        public CustomerDTO MapCustomerToDTO(Customer customer)
        {
            return new CustomerDTO(customer.CustomerId, customer.CustomerName,customer.CustomerNumber, customer.TotalBill);
        }
    }
}
