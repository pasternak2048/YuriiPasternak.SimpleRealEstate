using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations.Location
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.Region)
                .WithMany(p => p.Districts)
                .HasForeignKey(e => e.RegionId);
        }
    }
}
