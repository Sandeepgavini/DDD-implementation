using Shopping.Domain.DTO;
using System.Collections.Generic;

namespace Shopping.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public List<Product> PurchasedProducts = new List<Product>();
        /* public List<ProductDTO> Products { get; set; }
           private List<Product> _purchasedProducts;
           public IReadOnlyCollection<Product> PurchasedProducts => _purchasedProducts;*/
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
            PurchasedProducts.Add(product);
            TotalBill += product.ProductPrice;
        }
/*
        public void AddProductsToList(List<ProductDTO> products)
        {
            Products = products;
        }*/
       
    }
}
