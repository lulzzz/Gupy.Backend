using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(c => c.Id);

            entity.HasOne(c => c.Photo)
                .WithOne()
                .HasForeignKey<Category>(c => c.PhotoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            entity.Property(c => c.Name)
                .HasMaxLength(55)
                .IsRequired();
        }
    }
}