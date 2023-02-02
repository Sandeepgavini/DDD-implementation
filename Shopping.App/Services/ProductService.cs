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
            return MapProductsToProductView(_productRepository.GetAllProducts());
        }

        public ProductViewDTO GetProductDetails(string productName)
        {
            return MapProductToProductView(_productRepository.GetProductDetails(productName));
        }

        public bool CheckForProduct(int productId)
        {
            return _productRepository.CheckForProduct(productId);
        }

        public ProductViewDTO AddNewProduct(ProductViewDTO product)
        {
           _productRepository.AddNewProduct(MapProductViewToProduct(product));
            return product;
        }

        public Product MapProductViewToProduct(ProductViewDTO productView)
        {
            return new Product(productView.ProductName, productView.ProductQuantity, productView.ProductPrice);
        }

        public ProductViewDTO MapProductToProductView(Product product)
        {
            return new ProductViewDTO(product.ProductName, product.ProductPrice, product.Quantity);
        }

        public List<ProductViewDTO> MapProductsToProductView(List<Product> products)
        {
            var productsView = new List<ProductViewDTO>();
            foreach(var product in products)
            {
                productsView.Add(MapProductToProductView(product));
            }
            return productsView;
        }

        public ProductViewDTO UpdateProductQuantity(string productName, int quantity)
        {
            return MapProductToProductView(_productRepository.UpdateProductQuantity(productName, quantity));
        }
    }
}
