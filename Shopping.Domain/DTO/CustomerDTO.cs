using Shopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.DTO
{
    public class CustomerDTO
    {
        public int CustomerId { get;  set; }
        public string? CustomerName { get;  set; }
        public List<Product> PurchasedProducts { get; set; }
        public double TotalBill { get;  set; }
        public CustomerDTO(int customerId, string? customerName)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            TotalBill = 0;
            PurchasedProducts = new List<Product>();


        }
    }
}
