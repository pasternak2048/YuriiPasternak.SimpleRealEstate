using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;

namespace YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces
{
    public interface ISimpleRealEstateDbContext
    {
        DbSet<HeatingType> HeatingTypes { get; }
        DbSet<Location> Locations { get; }
        DbSet<LocationType> LocationTypes { get; }
        DbSet<PlanningType> PlanningTypes { get; }
        DbSet<Realty> Realties { get; }
        DbSet<RealtyHeatingType> RealtyHeatingTypes { get; }
        DbSet<RealtyPlanningType> RealtyPlanningTypes { get; }
        DbSet<RealtyStatus> RealtyStatuses { get; }
        DbSet<RealtyType> RealtyTypes { get; }
        DbSet<RealtyWallType> RealtyWallTypes { get; }
        DbSet<WallType> WallTypes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
