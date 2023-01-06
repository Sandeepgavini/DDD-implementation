using Shopping.Domain.DTO;
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

        public Product GetProductDetails(string productName)
        {
            return _productRepository.GetProductDetails(productName);
        }

        public bool CheckForProduct(int productId)
        {
            return _productRepository.CheckForProduct(productId);
        }

        public Product AddNewProduct(Product product)
        {
            return _productRepository.AddNewProduct(product);
        }
    }
}
