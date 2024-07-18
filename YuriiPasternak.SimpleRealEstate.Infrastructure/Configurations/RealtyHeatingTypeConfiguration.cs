using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyHeatingTypeConfiguration : IEntityTypeConfiguration<RealtyHeatingType>
    {
        public void Configure(EntityTypeBuilder<RealtyHeatingType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Creator)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.HeatingType)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.HeatingTypeId);
        }
    }
}
