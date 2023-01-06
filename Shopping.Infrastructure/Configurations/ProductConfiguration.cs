using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductPrice).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
        }
    }
}
