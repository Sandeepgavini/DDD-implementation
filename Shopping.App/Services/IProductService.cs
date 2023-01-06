using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public interface IProductService
    {
        bool CheckForProduct(int productId);
        List<Product> GetAllProducts();
        Product GetProductDetails(string productName);
        Product AddNewProduct(Product product);
    }
}