using YuriiPasternak.SimpleRealEstate.WebAPI.Extensions;
using YuriiPasternak.SimpleRealEstate.Application;
using YuriiPasternak.SimpleRealEstate.Infrastructure;
using System.Reflection;
using System.Security.Claims;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwaggerServices();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureApplication(); 
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    var user = context.User;
    var currentUser = context.RequestServices.GetRequiredService<ICurrentUserInitializer>();

    currentUser.UserId ??= Guid.TryParse(user.FindFirstValue("Id"),
                out var result)
                ? result
                : default(Guid?);

    currentUser.UserRole ??= user.FindFirstValue("Role");

    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseErrorHandler();

app.Run();
