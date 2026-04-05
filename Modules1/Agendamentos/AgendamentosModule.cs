using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Agendamentos.Application.Interfaces;
using NexFlowSaude.Api.Modules.Agendamentos.Application.Services;
using NexFlowSaude.Api.Modules.Agendamentos.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Agendamentos.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Agendamentos;

public static class AgendamentosModule
{
    public static IServiceCollection AddAgendamentosModule(this IServiceCollection services)
    {
        services.AddScoped<IAgendamentoService, AgendamentoService>();
        services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
        return services;
    }
}
