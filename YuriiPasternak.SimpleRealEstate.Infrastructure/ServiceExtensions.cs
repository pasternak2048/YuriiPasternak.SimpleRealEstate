using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Context;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(connectionString));

            services.AddIdentityCore<AppUser>()
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<DataContext>();
        }
    }
}
