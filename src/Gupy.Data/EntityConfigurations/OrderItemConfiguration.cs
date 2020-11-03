using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> entity)
        {
            entity.ToTable("OrderItems");
            entity.HasKey(oi => new {oi.OrderId, oi.ProductId});

            entity.Property(oi => oi.Quantity)
                .IsRequired();

            entity.Property(oi => oi.PricePerUnit)
                .IsRequired();
        }
    }
}