using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class PlanningTypeConfiguration : IEntityTypeConfiguration<PlanningType>
    {
        public void Configure(EntityTypeBuilder<PlanningType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData(
                new PlanningType() { Id = PlanningTypeEnum.None, Name = "None" },
                new PlanningType() { Id = PlanningTypeEnum.Jacuzzi, Name = "Jacuzzi" },
                new PlanningType() { Id = PlanningTypeEnum.MultiLevel, Name = "MultiLevel" },
                new PlanningType() { Id = PlanningTypeEnum.Terrace, Name = "Terrace" },
                new PlanningType() { Id = PlanningTypeEnum.Penthouse, Name = "Penthouse" },
                new PlanningType() { Id = PlanningTypeEnum.WithoutFurniture, Name = "WithoutFurniture" }
                );
        }
    }
}
