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
            var products = _shoppingContext.Products.Where(x => x.CustomerId == customerId).ToList();
            return products;
        }

        public List<Product> GetAllProducts()
        {
            return _shoppingContext.Products.ToList();
        }
        public bool CheckForProduct(int productId)
        {
            return _shoppingContext.Products.Any(x => x.ProductId == productId);
        }
    }
}
