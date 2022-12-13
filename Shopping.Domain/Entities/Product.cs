using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get;  set; }
        public double ProductPrice { get;  set; }
        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }  
        public Product() { }
        public Product(string productName, double productPrice,int customerId)
        {

            ProductName = productName;
            ProductPrice = productPrice;
            CustomerId = customerId;
            

        }
        public Product(string productName, double productPrice,Customer customer)
        {

            ProductName = productName;
            ProductPrice = productPrice;
            Customer = customer;


        }
    }
}
