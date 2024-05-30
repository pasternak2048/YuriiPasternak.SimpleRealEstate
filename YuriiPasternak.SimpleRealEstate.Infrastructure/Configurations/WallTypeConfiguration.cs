using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class WallTypeConfiguration : IEntityTypeConfiguration<WallType>
    {
        public void Configure(EntityTypeBuilder<WallType> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasData(
               new WallType() { Id = WallTypeEnum.None, Name = "None" },
               new WallType() { Id = WallTypeEnum.Brick, Name = "Brick" },
               new WallType() { Id = WallTypeEnum.Concrete, Name = "Concrete" },
               new WallType() { Id = WallTypeEnum.Wood, Name = "Wood" }
               );
        }
    }
}
