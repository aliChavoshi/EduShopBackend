using Application.Contracts;
using Application.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Context;
using Infrastructure.Security;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastructure;

public static class ConfigureService
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //connection string sql server
        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });
        //connection string redis
        services.AddSingleton<IConnectionMultiplexer>(opt =>
        {
            var options = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
            return ConnectionMultiplexer.Connect(options);
        });
        //DI
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IUnitOWork, UnitOWork>();
        //Identity
        services.AddIdentityService(configuration);
        return services;
    }
}