using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(p => p.Id);

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(55);

            entity.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(p => p.Price)
                .IsRequired();

            entity.Property(p => p.IsAvailable)
                .IsRequired();

            entity.Property(p => p.PromotionPrice)
                .IsRequired(false);
            entity.Property(p => p.PromotionEndDate)
                .IsRequired(false);
        }
    }
}