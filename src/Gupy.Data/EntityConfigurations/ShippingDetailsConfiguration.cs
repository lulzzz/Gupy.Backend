using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class ShippingDetailsConfiguration : IEntityTypeConfiguration<ShippingDetails>
    {
        public void Configure(EntityTypeBuilder<ShippingDetails> entity)
        {
            entity.HasKey(s => s.Id);

            entity.HasOne(s => s.TelegramUser)
                .WithMany(u => u.ShippingDetails)
                .HasForeignKey(s => s.TelegramUserId)
                .IsRequired();

            entity.Property(s => s.ReceiverName).HasMaxLength(256).IsRequired();
            entity.Property(s => s.PhoneNumber).HasMaxLength(64).IsRequired();
            entity.Property(s => s.Address).HasMaxLength(256).IsRequired();
        }
    }
}