using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.Domain.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        bool CheckForProduct(int productId);
        Product GetProductDetails(string productName);
        Product AddNewProduct(Product product);
        Product UpdateProductQuantity(string productName, int quantity);
    }
}
