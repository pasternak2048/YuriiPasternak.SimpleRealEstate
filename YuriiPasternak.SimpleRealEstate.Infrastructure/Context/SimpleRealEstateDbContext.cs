using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Context
{
    public class SimpleRealEstateDbContext : IdentityDbContext<AppUser, AppRole, Guid>, ISimpleRealEstateDbContext
    {
        public SimpleRealEstateDbContext(DbContextOptions<SimpleRealEstateDbContext> options) : base(options)
        {
        }

        public DbSet<HeatingType> HeatingTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationType> LocationTypes { get; set; }
        public DbSet<PlanningType> PlanningTypes { get; set; }
        public DbSet<Realty> Realties { get; set; }
        public DbSet<RealtyHeatingType> RealtyHeatingTypes { get; set; }
        public DbSet<RealtyPlanningType> RealtyPlanningTypes { get; set; }
        public DbSet<RealtyStatus> RealtyStatuses { get; set; }
        public DbSet<RealtyType> RealtyTypes { get; set; }
        public DbSet<RealtyWallType> RealtyWallTypes { get; set; }
        public DbSet<WallType> WallTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
