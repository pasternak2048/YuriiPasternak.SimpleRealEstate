using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
    {
        public void Configure(EntityTypeBuilder<LocationType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData(
                new LocationType() { Id = LocationTypeEnum.None, Name = "None" },
                new LocationType() { Id = LocationTypeEnum.Region, Name = "Region" },
                new LocationType() { Id = LocationTypeEnum.District, Name = "District" },
                new LocationType() { Id = LocationTypeEnum.Community, Name = "Community" },
                new LocationType() { Id = LocationTypeEnum.City, Name = "City" },
                new LocationType() { Id = LocationTypeEnum.CityDistrict, Name = "CityDistrict" },
                new LocationType() { Id = LocationTypeEnum.Village, Name = "Village" },
                new LocationType() { Id = LocationTypeEnum.SmallTown, Name = "SmallTown" }
                );
        }
    }
}
