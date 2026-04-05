using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Pacientes.Application.Interfaces;
using NexFlowSaude.Api.Modules.Pacientes.Application.Services;
using NexFlowSaude.Api.Modules.Pacientes.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Pacientes.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Pacientes;

public static class PacientesModule
{
    public static IServiceCollection AddPacientesModule(this IServiceCollection services)
    {
        services.AddScoped<IPacienteService, PacienteService>();
        services.AddScoped<IPacienteRepository, PacienteRepository>();
        return services;
    }
}
