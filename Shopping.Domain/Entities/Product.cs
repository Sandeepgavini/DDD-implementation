using System;

namespace Shopping.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get;  set; }
        public double ProductPrice { get;  set; }
        public int Quantity { get; set; }
        public Cart Cart { get; set; }

        public Product() { }

        public Product(string productName,int quantity,double productPrice=0)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
        }
    }
}
