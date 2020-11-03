using Gupy.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gupy.Data.EntityConfigurations
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> entity)
        {
            entity.HasKey(r => r.Id);

            entity.HasOne(r => r.TelegramUser)
                .WithMany(u => u.Reports)
                .HasForeignKey(r => r.TelegramUserId)
                .IsRequired();

            entity.Property(r => r.Message).HasMaxLength(4096);
            
            entity.Property(r => r.DateReported)
                .IsRequired();

            entity.Property(r => r.ReportType)
                .IsRequired();
        }
    }
}