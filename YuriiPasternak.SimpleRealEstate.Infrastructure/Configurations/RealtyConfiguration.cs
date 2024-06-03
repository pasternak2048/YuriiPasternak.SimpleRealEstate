using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyConfiguration : IEntityTypeConfiguration<Realty>
    {
        public void Configure(EntityTypeBuilder<Realty> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.Property(e => e.IsDeleted).HasDefaultValue(false);

            builder.HasOne(e => e.RealtyStatus)
                .WithMany(p => p.Realties)
                .HasForeignKey(e => e.RealtyStatusId);

            builder.HasOne(e => e.RealtyType)
               .WithMany(p => p.Realties)
               .HasForeignKey(e => e.RealtyTypeId);

            builder.HasOne(e => e.Address)
                .WithMany(p => p.Realties)
                .HasForeignKey(e => e.AddressId);
        }
    }
}
