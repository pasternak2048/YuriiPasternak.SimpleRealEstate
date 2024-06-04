using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class TerritorialObjectTypeConfiguration : IEntityTypeConfiguration<TerritorialObjectType>
    {
        public void Configure(EntityTypeBuilder<TerritorialObjectType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.None, Name = "None" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.Region, Name = "Region" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.District, Name = "District" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.Community, Name = "Community" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.City, Name = "City" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.CityDistrict, Name = "CityDistrict" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.Village, Name = "Village" },
               new TerritorialObjectType() { Id = TerritorialObjectTypeEnum.SmallTown, Name = "SmallTown" }
               );
        }
    }
}
