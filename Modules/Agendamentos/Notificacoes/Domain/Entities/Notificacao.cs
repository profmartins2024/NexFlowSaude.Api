using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Notificacoes.Domain.Entities;

public sealed class Notificacao : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public bool Lida { get; set; }
    public Guid? UsuarioId { get; set; }
}
