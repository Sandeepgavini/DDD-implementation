using Shopping.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Domain.Entities
{
    public class Cart
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public List<Product> Products { get; set; }
        public double TotalBill { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }  

        public Cart() { }

        public Cart(int customerId, int productId)
        {
            CustomerId = customerId;
            ProductId = productId;
            TotalBill = 0;
            Products = new List<Product>();
            CustomerId = customerId;
            ProductId = productId;
        }

        public void AddProductToCustomer(Product product)
        {
            TotalBill += product.ProductPrice;
            CheckoutDiscount();
            Products.Add(product);
        }

        public void CheckoutDiscount()
        {
            if (TotalBill > 500)
            {
                TotalBill -= TotalBill * Constant.TCD;
            }
            if (TotalBill > 1000)
            {
                TotalBill -= TotalBill * Constant.FCD;
            }
        }
    }
}
