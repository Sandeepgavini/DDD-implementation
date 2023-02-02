using Shopping.Domain.Common;
using System.Collections.Generic;

namespace Shopping.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public double TotalBill { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }

        public Cart() { }

        public Cart(int customerId)
        {
            CustomerId = customerId;
            Products = new List<Product>();
            TotalBill = 0;
        }

        public Cart(Customer customer)
        {
            Customer = customer;
            CustomerId = customer.CustomerId;
            TotalBill = 0;
        }

        public void AddProductToCustomer(Product product,int quantity)
        {
            Products.Add(product);
            TotalBill += product.ProductPrice * quantity;
            CheckoutDiscount();
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
