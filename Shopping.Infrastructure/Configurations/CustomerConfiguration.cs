using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Domain.Entities;

namespace Shopping.Infrastructure.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.CustomerName).HasDefaultValue("Mathew Arnold");
            builder.Property(x => x.TotalBill).HasDefaultValue(0);
        }
    }
}
