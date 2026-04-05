using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Faturamento.Application.Interfaces;
using NexFlowSaude.Api.Modules.Faturamento.Application.Services;
using NexFlowSaude.Api.Modules.Faturamento.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Faturamento.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Faturamento;

public static class FaturamentoModule
{
    public static IServiceCollection AddFaturamentoModule(this IServiceCollection services)
    {
        services.AddScoped<IFaturamentoService, FaturamentoService>();
        services.AddScoped<IFaturamentoRepository, FaturamentoRepository>();
        return services;
    }
}
