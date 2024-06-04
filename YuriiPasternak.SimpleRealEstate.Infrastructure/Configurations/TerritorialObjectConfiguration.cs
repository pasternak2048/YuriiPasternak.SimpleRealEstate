using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class TerritorialObjectConfiguration : IEntityTypeConfiguration<TerritorialObject>
    {
        public void Configure(EntityTypeBuilder<TerritorialObject> builder)
        {
            builder.Property(e => e.Id).HasColumnName("ID");

            builder.HasOne(e => e.TerritorialObjectType)
                .WithMany(p => p.TerritorialObjects)
                .HasForeignKey(p => p.TypeId);
        }
    }
}
