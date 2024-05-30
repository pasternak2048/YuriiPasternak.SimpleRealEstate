using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.LocationType)
                .WithMany(p => p.Locations)
                .HasForeignKey(e => e.LocationTypeId);

            builder.HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId);

            builder.HasOne(e => e.District)
                .WithMany()
                .HasForeignKey(e => e.DistrictId);

            builder.HasOne(e => e.City)
                .WithMany()
                .HasForeignKey(e => e.CityId);

            builder.HasOne(e => e.CityArea)
                .WithMany()
                .HasForeignKey(e => e.CityAreaId);
        }
    }
}
