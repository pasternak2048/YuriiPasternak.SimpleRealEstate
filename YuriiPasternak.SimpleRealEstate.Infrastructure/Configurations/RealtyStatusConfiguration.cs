using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Enums;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyStatusConfiguration : IEntityTypeConfiguration<RealtyStatus>
    {
        public void Configure(EntityTypeBuilder<RealtyStatus> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasData(
                new RealtyStatus() { Id = RealtyStatusEnum.Unknown, Name = "Unknown" },
                new RealtyStatus() { Id = RealtyStatusEnum.Draft, Name = "Draft" },
                new RealtyStatus() { Id = RealtyStatusEnum.NonVerified, Name = "NonVerified" },
                new RealtyStatus() { Id = RealtyStatusEnum.Verified, Name = "Verified" }
                );
        }
    }
}
