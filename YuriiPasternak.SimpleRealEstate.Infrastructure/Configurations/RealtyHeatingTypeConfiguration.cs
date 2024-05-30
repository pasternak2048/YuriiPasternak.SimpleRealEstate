using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyHeatingTypeConfiguration : IEntityTypeConfiguration<RealtyHeatingType>
    {
        public void Configure(EntityTypeBuilder<RealtyHeatingType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.HeatingType)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.HeatingTypeId);
        }
    }
}
