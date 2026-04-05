using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Agendamentos.Domain.Entities;

public sealed class Agendamento : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
