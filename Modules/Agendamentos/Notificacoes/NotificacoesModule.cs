using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Notificacoes.Application.Interfaces;
using NexFlowSaude.Api.Modules.Notificacoes.Application.Services;
using NexFlowSaude.Api.Modules.Notificacoes.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Notificacoes.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Notificacoes;

public static class NotificacoesModule
{
    public static IServiceCollection AddNotificacoesModule(this IServiceCollection services)
    {
        services.AddScoped<INotificacaoService, NotificacaoService>();
        services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
        return services;
    }
}
