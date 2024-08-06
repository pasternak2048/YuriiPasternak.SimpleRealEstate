using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class HeatingTypeConfiguration : IEntityTypeConfiguration<HeatingType>
    {
        public void Configure(EntityTypeBuilder<HeatingType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData(
                new HeatingType() { Id = HeatingTypeEnum.None, Name = "None" },
                new HeatingType() { Id = HeatingTypeEnum.Electric, Name = "Electric" },
                new HeatingType() { Id = HeatingTypeEnum.Gas, Name = "Gas" },
                new HeatingType() { Id = HeatingTypeEnum.SolidFuel, Name = "SolidFuel" },
                new HeatingType() { Id = HeatingTypeEnum.Solar, Name = "Solar" },
                new HeatingType() { Id = HeatingTypeEnum.Geothermal, Name = "Geothermal" }
                );
        }
    }
}
