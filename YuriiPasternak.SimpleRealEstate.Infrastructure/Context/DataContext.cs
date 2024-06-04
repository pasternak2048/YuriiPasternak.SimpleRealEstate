using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Domain.Entities;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Interceptors;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Context
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>, IApplicationDbContext
    {
        private readonly AuditableEntityInterceptor _auditableEntityInterceptor;
        public DataContext(DbContextOptions<DataContext> options,
            AuditableEntityInterceptor auditableEntityInterceptor) : base(options)
        {
            _auditableEntityInterceptor = auditableEntityInterceptor;
        }

        public DbSet<HeatingType> HeatingTypes { get; set; }
        public DbSet<PlanningType> PlanningTypes { get; set; }
        public DbSet<Realty> Realties { get; set; }
        public DbSet<RealtyHeatingType> RealtyHeatingTypes { get; set; }
        public DbSet<RealtyPlanningType> RealtyPlanningTypes { get; set; }
        public DbSet<RealtyStatus> RealtyStatuses { get; set; }
        public DbSet<RealtyType> RealtyTypes { get; set; }
        public DbSet<RealtyWallType> RealtyWallTypes { get; set; }
        public DbSet<WallType> WallTypes { get; set; }
        public DbSet<TerritorialObject> TerritorialObjects { get; set; }
        public DbSet<TerritorialObjectType> TerritorialObjectTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            CreateForeignKeysForAuditableEntities(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntityInterceptor);
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine);
        }

        private void CreateForeignKeysForAuditableEntities(ModelBuilder modelBuilder)
        {
            var userMetadata = modelBuilder.Entity<AppUser>().Metadata;
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                if (entityType.ClrType.IsSubclassOf(typeof(AuditableEntity)))
                {
                    entityType.AddForeignKey(
                        new[] { entityType.FindProperty(nameof(AuditableEntity.CreatedById)) },
                        userMetadata.FindPrimaryKey(),
                        userMetadata)
                        .DeleteBehavior = DeleteBehavior.NoAction;


                    entityType.AddForeignKey(
                        new[] { entityType.FindProperty(nameof(AuditableEntity.ModifiedById)) },
                        userMetadata.FindPrimaryKey(),
                        userMetadata)
                        .DeleteBehavior = DeleteBehavior.NoAction;
                }
        }
    }
}
