using Shopping.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public List<Product> PurchasedProducts = new List<Product>();
        /*private List<Product> _purchasedProducts;
        public IReadOnlyCollection<Product> PurchasedProducts => _purchasedProducts;*/
        public double TotalBill { get; private set; } 
       public Customer() { }
        public Customer(string customerName)
        {
            //_purchasedProducts = new List<Product>();
            CustomerName = customerName;
            TotalBill = 0;
            
        }
     
        public void AddProduct(string productName,double productPrice,int customerId)
        {
            var product = new Product(productName, productPrice, customerId);
            //_purchasedProducts.Add(product);
            PurchasedProducts.Add(product);
            TotalBill += product.ProductPrice;
        }
      
       
    }
}
