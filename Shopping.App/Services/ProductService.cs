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

        public List<ProductViewDTO> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return MapProductViewToDTO(products);
        }

        public List<ProductDTO> GetProductsByCustomerId(int customerId)
        {
            var products =  _productRepository.GetProductsByCustomerId(customerId);
            return MapProductToDTO(products);
        }

        public bool CheckForProduct(int productId)
        {
            return _productRepository.CheckForProduct(productId);
        }

        public List<ProductDTO> MapProductToDTO(List<Product> products)
        {
            var productDtos = new List<ProductDTO>();
            foreach (var product in products)
            {
                var productDto = new ProductDTO(product.ProductId, product.ProductName, product.ProductPrice);
                productDtos.Add(productDto);
            }
            return productDtos;
        }

        public List<ProductViewDTO> MapProductViewToDTO(List<Product> products)
        {
            var productViewDtos = new List<ProductViewDTO>();
            foreach (var product in products)
            {
                var productDto = new ProductViewDTO(product.CustomerId, product.Customer.CustomerName,product.ProductId, product.ProductName, product.ProductPrice);
                productViewDtos.Add(productDto);
            }
            return productViewDtos;
        }
    }
}
