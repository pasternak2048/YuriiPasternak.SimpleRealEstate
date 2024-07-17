using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces.Authentication;
using YuriiPasternak.SimpleRealEstate.Domain.Identity;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Authentication;
using YuriiPasternak.SimpleRealEstate.Infrastructure.Context;

namespace YuriiPasternak.SimpleRealEstate.Infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SimpleRealEstateDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddIdentityCore<AppUser>()
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<SimpleRealEstateDbContext>();

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
            services.AddHttpContextAccessor();
        }
    }
}
