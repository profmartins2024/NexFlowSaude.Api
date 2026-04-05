using NexFlowSaude.Api.Modules.Chat.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Chat.Domain.Interfaces;

public interface IChatRepository
{
    Task AdicionarConversaAsync(Conversa entidade, CancellationToken cancellationToken = default);
    Task AdicionarMensagemAsync(MensagemChat entidade, CancellationToken cancellationToken = default);
}
