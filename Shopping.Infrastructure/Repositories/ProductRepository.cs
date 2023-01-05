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

        public List<ProductDTO> GetProductsByCustomerId(int customerId)
        {
            var products = _shoppingContext.Products.Where(x => x.Customer.CustomerId == customerId).ToList();
            var productDtos = new List<ProductDTO>();
            foreach (var product in products)
            {
                var productDto = new ProductDTO(product.ProductId, product.ProductName, product.ProductPrice);
                productDtos.Add(productDto);
            }
            return productDtos;
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
