using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public List<Product> GetProductsByCustomerId(int customerId)
        {
            return _productRepository.GetProductsByCustomerId(customerId);
        }

        public bool CheckForProduct(int productId)
        {
            return _productRepository.CheckForProduct(productId);
        }
    }
}
