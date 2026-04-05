using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Ia.Domain.Entities;

public sealed class HistoricoIa : BaseEntity
{
    public string Pergunta { get; set; } = string.Empty;
    public string Resposta { get; set; } = string.Empty;
    public string? Contexto { get; set; }
}
