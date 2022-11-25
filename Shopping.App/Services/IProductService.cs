using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public interface IProductService
    {
       
        bool CheckForProduct(int productId);
        List<Product> GetAllProducts();
        List<Product> GetProductsByCustomerId(int customerId);
    }
}