using Shopping.Domain.Entities;
using System.Collections.Generic;

namespace Shopping.Domain.Repository
{
    public interface ICartRepository
    {
        Cart GetCustomerCartDetails(int customerId);
        Cart AddProductToCart(int customerId, Product product,int quantity);
        void UpdateProductQuantityFromCart(Product product,int quantity);
        bool DeleteCart(int customerId);

    }
}
