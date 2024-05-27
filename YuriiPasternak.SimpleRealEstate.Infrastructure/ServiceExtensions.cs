using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces.Authentication;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Authentication;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Context;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Interceptors;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Services;

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

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<AuditableEntityInterceptor>();
            services.AddScoped<ICurrentUserInitializer, CurrentUserInitializer>();
        }
    }
}
