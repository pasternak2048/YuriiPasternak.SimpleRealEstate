using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations.Location
{
    public class TerritorialCommunityConfiguration : IEntityTypeConfiguration<TerritorialCommunity>
    {
        public void Configure(EntityTypeBuilder<TerritorialCommunity> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.District)
                .WithMany(p => p.TerritorialCommunities)
                .HasForeignKey(e => e.DistrictId);
        }
    }
}
