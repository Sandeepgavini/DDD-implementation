using System.Collections.Generic;

namespace Shopping.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public List<Product> Products { get; set; }
        public double TotalBill { get; private set; } 
        
        public Customer() { }
        
        public Customer(string customerName)
        {
            CustomerName = customerName;
            TotalBill = 0;
        }
     
        public void AddProduct(string productName,double productPrice)
        {
            var product = new Product(productName, productPrice);
            TotalBill += product.ProductPrice;
        }

        public void AddProductsToList(List<Product> products)
        {
            Products = products;
        }

    }
}
