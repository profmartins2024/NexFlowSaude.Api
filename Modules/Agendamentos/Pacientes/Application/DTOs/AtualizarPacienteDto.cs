namespace NexFlowSaude.Api.Modules.Pacientes.Application.DTOs;

public sealed class AtualizarPacienteDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
