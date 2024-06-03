using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations.Location
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.TerritorialCommunity)
                .WithMany(p => p.Cities)
                .HasForeignKey(e => e.TerritorialCommunityId);
        }
    }
}
