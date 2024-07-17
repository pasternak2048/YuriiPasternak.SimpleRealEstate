using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure.Context
{
    public class SimpleRealEstateDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public SimpleRealEstateDbContext(DbContextOptions<SimpleRealEstateDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
