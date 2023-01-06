using System;
using System.Collections.Generic;
using Shopping.Domain.Common;

namespace Shopping.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public DateTime CustomerCreatedAt { get; private set; }
        public string CustomerNumber { get; set; }
        public Cart Cart { get; set; }

        public Customer() { }
        
        public Customer(string customerName,string customerNumber)
        {
            CustomerName = customerName;
            CustomerNumber = customerNumber;
            CustomerCreatedAt = DateTime.Now;
        }
    }
}
