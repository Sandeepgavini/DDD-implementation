using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Shopping.Infrastructure.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(cart => cart.Id);
            builder.HasOne(cart => cart.Customer)
                .WithOne(customer => customer.Cart)
                .HasForeignKey<Cart>(cart=>cart.CustomerId);
        }
    }
}
