using Shopping.Domain.DTO;
using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.App.Services
{
    public interface IProductService
    {
        bool CheckForProduct(int productId);
        List<ProductViewDTO> GetAllProducts();
        ProductViewDTO GetProductDetails(string productName);
        ProductViewDTO AddNewProduct(ProductViewDTO product);
        ProductViewDTO UpdateProductQuantity(string productName,int quantity);
        Product MapProductViewToProduct(ProductViewDTO productView);
        ProductViewDTO MapProductToProductView(Product product);
        List<ProductViewDTO> MapProductsToProductView(List<Product> products);
    }
}