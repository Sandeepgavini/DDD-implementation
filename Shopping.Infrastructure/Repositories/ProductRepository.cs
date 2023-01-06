using Microsoft.EntityFrameworkCore;
using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using Shopping.Infrastructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Infrastructure.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private ShoppingContext _shoppingContext;

        public ProductRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public Product GetProductDetails(string productName)
        {
           return _shoppingContext.Products.Where(x => x.ProductName == productName).FirstOrDefault();
        }

        public List<Product> GetAllProducts()
        {
            return _shoppingContext.Products.ToList();
        }

        public bool CheckForProduct(int productId)
        {
            return _shoppingContext.Products.FirstOrDefault(x => x.ProductId == productId).Quantity > 0;
        }

        public Product AddNewProduct(Product product)
        {
            _shoppingContext.Products.Add(product);
            _shoppingContext.SaveChanges();
            return product;
        }
    }
}
