using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Configurations
{
    public class RealtyPlanningTypeConfiguration : IEntityTypeConfiguration<RealtyPlanningType>
    {
        public void Configure(EntityTypeBuilder<RealtyPlanningType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Creator)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(e => e.Realty)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.RealtyId);

            builder.HasOne(e => e.PlanningType)
                .WithMany(p => p.RealtyPlanningTypes)
                .HasForeignKey(e => e.PlanningTypeId);
        }
    }
}
