using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Chat.Domain.Entities;

public sealed class MensagemChat : BaseEntity
{
    public Guid ConversaId { get; set; }
    public Guid RemetenteId { get; set; }
    public string Conteudo { get; set; } = string.Empty;
    public DateTime EnviadaEm { get; set; } = DateTime.UtcNow;
}
