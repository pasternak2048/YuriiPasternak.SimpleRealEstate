using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<ICurrentUserInitializer, CurrentUserInitializer>();
            services.AddScoped<AuditableEntityInterceptor>();
            services.AddHttpContextAccessor();
        }
    }
}
