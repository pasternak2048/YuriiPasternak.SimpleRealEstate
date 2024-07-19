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

            builder.HasOne(e => e.Creator)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.RealtyId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(e => e.HeatingType)
                .WithMany(p => p.RealtyHeatingTypes)
                .HasForeignKey(e => e.HeatingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
