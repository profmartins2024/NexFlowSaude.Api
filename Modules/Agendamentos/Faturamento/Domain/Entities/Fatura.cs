using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Faturamento.Domain.Entities;

public sealed class Fatura : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
