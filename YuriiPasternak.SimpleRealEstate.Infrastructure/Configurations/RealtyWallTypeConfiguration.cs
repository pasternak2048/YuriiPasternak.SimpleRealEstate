using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyWallTypeConfiguration : IEntityTypeConfiguration<RealtyWallType>
    {
        public void Configure(EntityTypeBuilder<RealtyWallType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.Creator)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.WallType)
                .WithMany(p => p.RealtyWallTypes)
                .HasForeignKey(e => e.WallTypeId);
        }
    }
}
