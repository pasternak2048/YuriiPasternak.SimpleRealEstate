using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YuriiPasternak.SimpleRealEstate.Domain.Common;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Interceptors;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Context
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        private readonly AuditableEntityInterceptor _auditableEntityInterceptor;
        public DataContext(DbContextOptions<DataContext> options,
            AuditableEntityInterceptor auditableEntityInterceptor) : base(options)
        {
            _auditableEntityInterceptor = auditableEntityInterceptor;
        }

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
