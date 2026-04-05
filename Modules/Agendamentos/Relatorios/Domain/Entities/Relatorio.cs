using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Relatorios.Domain.Entities;

public sealed class Relatorio : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
