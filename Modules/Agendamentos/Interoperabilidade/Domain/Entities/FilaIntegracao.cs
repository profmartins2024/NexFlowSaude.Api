using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Enums;
using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Entities;

public sealed class FilaIntegracao : BaseEntity
{
    public SistemaExterno Sistema { get; set; }
    public string TipoRecurso { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
    public StatusIntegracao Status { get; set; } = StatusIntegracao.Pendente;
    public int Tentativas { get; set; }
    public DateTime? ProcessadoEm { get; set; }
    public string? Erro { get; set; }
}
