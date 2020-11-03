using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasKey(o => o.Id);

            entity.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .IsRequired();

            entity.HasOne(o => o.ShippingDetails)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.ShippingDetailsId)
                .IsRequired();

            entity.Ignore(o => o.TotalSum);

            entity.Property(o => o.DateOrdered)
                .IsRequired();

            entity.Property(o => o.DateShipped)
                .IsRequired(false);

            entity.Property(o => o.OrderStatus)
                .IsRequired();
        }
    }
}