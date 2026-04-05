using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Interoperabilidade.Application.Interfaces;
using NexFlowSaude.Api.Modules.Interoperabilidade.Application.Services;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Interoperabilidade.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Interoperabilidade;

public static class InteroperabilidadeModule
{
    public static IServiceCollection AddInteroperabilidadeModule(this IServiceCollection services)
    {
        services.AddScoped<IInteroperabilidadeService, InteroperabilidadeService>();
        services.AddScoped<IIntegracaoExternaRepository, IntegracaoExternaRepository>();
        return services;
    }
}
