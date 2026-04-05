namespace NexFlowSaude.Api.Modules.Pacientes.Application.DTOs;

public sealed class PacienteRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public string? CPF { get; set; }\n    public string? CNS { get; set; }
}
