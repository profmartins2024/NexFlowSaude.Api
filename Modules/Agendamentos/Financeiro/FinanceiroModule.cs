using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Financeiro.Application.Interfaces;
using NexFlowSaude.Api.Modules.Financeiro.Application.Services;
using NexFlowSaude.Api.Modules.Financeiro.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Financeiro.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Financeiro;

public static class FinanceiroModule
{
    public static IServiceCollection AddFinanceiroModule(this IServiceCollection services)
    {
        services.AddScoped<IFinanceiroService, FinanceiroService>();
        services.AddScoped<IFinanceiroRepository, FinanceiroRepository>();
        return services;
    }
}
