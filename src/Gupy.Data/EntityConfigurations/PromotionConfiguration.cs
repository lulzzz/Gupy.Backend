using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> entity)
        {
            entity.ToTable("promotions");
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Product)
                .WithOne(p => p.Promotion)
                .HasForeignKey<Product>(p => p.PromotionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(p => p.Message).HasMaxLength(256);
        }
    }
}