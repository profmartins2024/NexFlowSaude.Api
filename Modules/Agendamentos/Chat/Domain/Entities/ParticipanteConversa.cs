using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Chat.Domain.Entities;

public sealed class ParticipanteConversa : BaseEntity
{
    public Guid ConversaId { get; set; }
    public Guid UsuarioId { get; set; }
}
