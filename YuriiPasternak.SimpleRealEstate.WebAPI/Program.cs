using System.Reflection;
using System.Security.Claims;
using YuriiPasternak.SimpleRealEstate.Application.Common.Interfaces;
using YuriiPasternak.SimpleRealEstate.Infrastructure;
using YuriiPasternak.SimpleRealEstate.WebAPI.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerServices();
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddHttpContextAccessor();

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

    currentUser.UserId ??= user.FindFirstValue("Id");

    currentUser.UserRole ??= user.FindFirstValue(ClaimTypes.Role);

    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();