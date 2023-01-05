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

        public List<Product> GetProductsByCustomerId(int customerId)
        {
           return _shoppingContext.Products.Where(x => x.Customer.CustomerId == customerId).ToList();
        }

        public List<Product> GetAllProducts()
        {
            return _shoppingContext.Products.Include(x=>x.Customer).ToList();
        }

        public bool CheckForProduct(int productId)
        {
            return _shoppingContext.Products.FirstOrDefault(x => x.ProductId == productId) == null;
        }
    }
}
