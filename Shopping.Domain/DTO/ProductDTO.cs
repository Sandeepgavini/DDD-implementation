using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Domain.DTO
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public ProductDTO(int productId,string productName,double productPrice)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
        }
    }
}
