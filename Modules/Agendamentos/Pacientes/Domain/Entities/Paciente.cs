using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Pacientes.Domain.Entities;

public sealed class Paciente : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public string? CPF { get; set; }\n    public string? CNS { get; set; }\n    public DateTime? DataNascimento { get; set; }
}
