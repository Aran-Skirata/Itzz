using Microsoft.EntityFrameworkCore;

namespace Itzz.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MedFiszkiApi.Data.DataContext>(options =>
        {
            options.UseSqlite(config.GetConnectionString("Database"));
        });

        return services;
    }
}