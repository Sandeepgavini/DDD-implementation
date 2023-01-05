using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public interface IProductService
    {
        bool CheckForProduct(int productId);
        List<ProductDTO> GetAllProducts();
        List<ProductDTO> GetProductsByCustomerId(int customerId);
        public List<ProductDTO> MapProductToDTO(List<Product> products);
    }
}