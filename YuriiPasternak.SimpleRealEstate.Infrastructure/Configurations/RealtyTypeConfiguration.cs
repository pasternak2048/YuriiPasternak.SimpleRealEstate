using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyTypeConfiguration : IEntityTypeConfiguration<RealtyType>
    {
        public void Configure(EntityTypeBuilder<RealtyType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData(
                new RealtyType() { Id = RealtyTypeEnum.None, Name = "None" },
                new RealtyType() { Id = RealtyTypeEnum.Flat, Name = "Flat" },
                new RealtyType() { Id = RealtyTypeEnum.House, Name = "House" },
                new RealtyType() { Id = RealtyTypeEnum.Commercial, Name = "Commercial" },
                new RealtyType() { Id = RealtyTypeEnum.Planning, Name = "Planning" },
                new RealtyType() { Id = RealtyTypeEnum.PlaceOnly, Name = "PlaceOnly" }
                );
        }
    }
}
