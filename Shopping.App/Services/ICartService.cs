using Shopping.Domain.DTO;
using Shopping.Domain.Entities;

namespace Shopping.App.Services
{
    public interface ICartService
    {
        Cart AddProductToCart(int customerId, ProductDTO productDTO);
    }
}