using System;
using System.Collections.Generic;
using Shopping.Domain.Common;

namespace Shopping.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }
        public List<Product> Products { get; set; }
        public double TotalBill { get; private set; }
        public DateTime CustomerCreatedAt { get; private set; }
        public double Discount { get; private set; }
        public string CustomerNumber { get; set; }

        public Customer() { }
        
        public Customer(string customerName,string customerNumber)
        {
            CustomerName = customerName;
            CustomerNumber = customerNumber;
            CustomerCreatedAt = DateTime.Now;
            Discount = 0;
            TotalBill = 0;
        }
     
        public void AddProductsToList(Product product)
        {
            Products.Add(product);
            TotalBill += product.ProductPrice; 
            CheckOutDiscount();
            TotalBill -= TotalBill - Discount;
        }

        public void CheckOutDiscount()
        {
            if(TotalBill > 500)
            {
                Discount = Constant.TCD;
            }
            if (TotalBill > 2000)
            {
                Discount = Constant.FCD;
            }
        }
    }
}
