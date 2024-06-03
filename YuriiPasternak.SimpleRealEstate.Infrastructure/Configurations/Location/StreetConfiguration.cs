using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations.Location
{
    public class StreetConfiguration : IEntityTypeConfiguration<Street>
    {
        public void Configure(EntityTypeBuilder<Street> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.City)
                .WithMany(p => p.Streets)
                .HasForeignKey(e => e.CityId);

            builder.HasOne(e => e.CityArea)
                .WithMany(p => p.Streets)
                .HasForeignKey(e => e.CityAreaId);
        }
    }
}
