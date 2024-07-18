using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyConfiguration : IEntityTypeConfiguration<Realty>
    {
        public void Configure(EntityTypeBuilder<Realty> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Creator)
                .WithMany(p => p.Realties)
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.RealtyStatus)
                .WithMany(p => p.Realties)
                .HasForeignKey(e => e.RealtyStatusId);

            builder.HasOne(e => e.RealtyType)
               .WithMany(p => p.Realties)
               .HasForeignKey(e => e.RealtyTypeId);

            builder.HasOne(e => e.Location)
                .WithMany(p => p.Realties)
                .HasForeignKey(e => e.LocationId);
        }
    }
}
