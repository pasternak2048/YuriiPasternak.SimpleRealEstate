using Microsoft.EntityFrameworkCore;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Entities.Location;

namespace YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<HeatingType> HeatingTypes { get; }
        DbSet<PlanningType> PlanningTypes { get; }
        DbSet<Realty> Realties { get; }
        DbSet<RealtyHeatingType> RealtyHeatingTypes { get; }
        DbSet<RealtyPlanningType> RealtyPlanningTypes { get; }
        DbSet<RealtyStatus> RealtyStatuses { get; }
        DbSet<RealtyType> RealtyTypes { get; }
        DbSet<RealtyWallType> RealtyWallTypes { get; }
        DbSet<WallType> WallTypes { get; }

        DbSet<Region> Regions { get; }
        DbSet<District> Districts { get; }
        DbSet<TerritorialCommunity> TerritorialCommunities { get; }
        DbSet<City> Cities { get; }
        DbSet<CityArea> CityAreas { get; }
        DbSet<Street> Streets { get; }
        DbSet<Address> Addresses { get; }
    }
}
