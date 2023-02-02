using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping.Domain.Entities;
using Shopping.Domain.Repository;
using Shopping.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopping.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private ShoppingContext _shoppingContext;

        public CartRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public Cart AddProductToCart(int customerId, Product product,int quantity)
        {
            var cart = _shoppingContext.ShoppingCart.Include(x=>x.Products).FirstOrDefault(cart => cart.CustomerId == customerId);
            cart.AddProductToCustomer(product,quantity);
            _shoppingContext.SaveChanges();
            return cart;
        }

        public bool DeleteCart(int customerId)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetAllCarts()
        {
            throw new NotImplementedException();
        }

        public Cart GetCustomerCartDetails(int customerId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProductQuantityFromCart(Product product,int quantity)
        {
            product.Quantity -= quantity;
            _shoppingContext.SaveChanges();
        }
    }
}
