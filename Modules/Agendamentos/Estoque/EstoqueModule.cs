using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Estoque.Application.Interfaces;
using NexFlowSaude.Api.Modules.Estoque.Application.Services;
using NexFlowSaude.Api.Modules.Estoque.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Estoque.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Estoque;

public static class EstoqueModule
{
    public static IServiceCollection AddEstoqueModule(this IServiceCollection services)
    {
        services.AddScoped<IEstoqueService, EstoqueService>();
        services.AddScoped<IEstoqueRepository, EstoqueRepository>();
        return services;
    }
}
