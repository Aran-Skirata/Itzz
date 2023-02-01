using Itzz.Data;
using Itzz.Interfaces;
using Itzz.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Itzz.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IRouteRepository, RouteRepository>();
        services.AddScoped<ICargoRepository, CargoRepository>();
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddDbContext<Data.DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("Database"));
        });

        return services;
    }
}