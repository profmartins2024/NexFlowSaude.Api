using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Enums;
using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Entities;

public sealed class IntegracaoExterna : BaseEntity
{
    public SistemaExterno Sistema { get; set; }
    public string Operacao { get; set; } = string.Empty;
    public string PayloadEnviado { get; set; } = string.Empty;
    public string? PayloadRetorno { get; set; }
    public StatusIntegracao Status { get; set; } = StatusIntegracao.Pendente;
    public string? ChaveExterna { get; set; }
    public string? Erro { get; set; }
}
