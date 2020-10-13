using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class TelegramUserConfiguration : IEntityTypeConfiguration<TelegramUser>
    {
        public void Configure(EntityTypeBuilder<TelegramUser> entity)
        {
            entity.HasKey(u => u.Id);

            entity.HasMany(u => u.ShippingDetails)
                .WithOne(s => s.TelegramUser)
                .HasForeignKey(s => s.TelegramUserId)
                .IsRequired();

            entity.HasMany(u => u.Reports)
                .WithOne(r => r.TelegramUser)
                .HasForeignKey(r => r.TelegramUserId)
                .IsRequired();

            entity.Property(u => u.UserName).HasMaxLength(64);
            entity.Property(u => u.PhoneNumber).HasMaxLength(64);
        }
    }
}