using Microsoft.AspNetCore.SignalR;

namespace NexFlowSaude.Api.Modules.Chat.Infrastructure.Hubs;

public sealed class ChatHub : Hub
{
    public async Task EnviarMensagem(string sala, string usuario, string mensagem)
    {
        await Clients.Group(sala).SendAsync("ReceberMensagem", usuario, mensagem);
    }

    public async Task EntrarNaSala(string sala)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, sala);
    }

    public async Task SairDaSala(string sala)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, sala);
    }
}
