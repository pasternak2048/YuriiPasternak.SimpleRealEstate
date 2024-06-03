using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations.Location
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.Street)
                .WithMany(p => p.Addresses)
                .HasForeignKey(e => e.StreetId);
        }
    }
}
