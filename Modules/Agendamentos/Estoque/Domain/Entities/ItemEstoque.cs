using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Estoque.Domain.Entities;

public sealed class ItemEstoque : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
