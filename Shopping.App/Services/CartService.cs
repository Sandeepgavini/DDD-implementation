using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shopping.App.Services
{
    public class CartService:ICartService
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public Cart AddProductToCart(int customerId, ProductDTO productDTO)
        {
            var product = _productRepository.GetProductDetails(productDTO.ProductName);
            if (product == null || product.Quantity - productDTO.ProductQuantity < 0)
            {
                return null;
            }
            _cartRepository.UpdateProductQuantityFromCart(product, productDTO.ProductQuantity);
            return _cartRepository.AddProductToCart(customerId, product,productDTO.ProductQuantity);
        }
    }
}
