using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.Domain.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        bool CheckForProduct(int productId);
        List<ProductDTO> GetProductsByCustomerId(int customerId);
    }
}
