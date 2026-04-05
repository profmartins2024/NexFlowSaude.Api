using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Ia.Application.Interfaces;
using NexFlowSaude.Api.Modules.Ia.Application.Services;
using NexFlowSaude.Api.Modules.Ia.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Ia.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Ia;

public static class IaModule
{
    public static IServiceCollection AddIaModule(this IServiceCollection services)
    {
        services.AddScoped<IIaService, IaService>();
        services.AddScoped<IHistoricoIaRepository, HistoricoIaRepository>();
        return services;
    }
}
