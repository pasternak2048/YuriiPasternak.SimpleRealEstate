using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations.Location
{
    public class CityAreaConfiguration : IEntityTypeConfiguration<CityArea>
    {
        public void Configure(EntityTypeBuilder<CityArea> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.City)
                .WithMany(p => p.CityAreas)
                .HasForeignKey(e => e.CityId);
        }
    }
}
