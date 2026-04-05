using Microsoft.Extensions.DependencyInjection;
using NexFlowSaude.Api.Modules.Chat.Application.Interfaces;
using NexFlowSaude.Api.Modules.Chat.Application.Services;
using NexFlowSaude.Api.Modules.Chat.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Chat.Infrastructure.Repositories;

namespace NexFlowSaude.Api.Modules.Chat;

public static class ChatModule
{
    public static IServiceCollection AddChatModule(this IServiceCollection services)
    {
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddSignalR();
        return services;
    }
}
