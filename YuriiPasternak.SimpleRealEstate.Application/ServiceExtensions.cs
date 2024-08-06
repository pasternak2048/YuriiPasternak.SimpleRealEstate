using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YuriiPasternak.SimpleRealEstate.Application.Common.Behaviors;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.CreateRealty;
using YuriiPasternak.SimpleRealEstate.Application.Features.RealtyFeatures.UpdateRealty;


namespace YuriiPasternak.SimpleRealEstate.Application
{
    public static class ServiceExtensions
    {
        public static void ConfigureApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddScoped<IValidator<CreateRealtyRequest>, CreateRealtyValidator>();
            services.AddScoped<IValidator<UpdateRealtyRequest>, UpdateRealtyValidator>();
        }
    }
}
