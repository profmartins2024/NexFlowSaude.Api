using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Shared.Settings;
using Serilog;

namespace NexFlowSaude.Api.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddNexFlowDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("ConnectionStrings:DefaultConnection não configurada.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }

    public static IServiceCollection AddSharedServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<RndsSettings>(configuration.GetSection("RndsSettings"));
        services.Configure<EsusSettings>(configuration.GetSection("EsusSettings"));
        services.Configure<GovBrSettings>(configuration.GetSection("GovBrSettings"));

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.File("Logs/nexflow-.log", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        return services;
    }
}
