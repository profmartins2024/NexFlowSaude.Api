using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Financeiro.Domain.Entities;

public sealed class LancamentoFinanceiro : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
