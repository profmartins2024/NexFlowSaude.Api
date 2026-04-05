using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Relatorios.Application.Interfaces;
using NexFlowSaude.Api.Modules.Relatorios.Application.Services;
using NexFlowSaude.Api.Modules.Relatorios.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Relatorios.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Relatorios;

public static class RelatoriosModule
{
    public static IServiceCollection AddRelatoriosModule(this IServiceCollection services)
    {
        services.AddScoped<IRelatorioService, RelatorioService>();
        services.AddScoped<IRelatorioRepository, RelatorioRepository>();
        return services;
    }
}
