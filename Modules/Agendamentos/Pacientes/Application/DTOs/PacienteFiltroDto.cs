namespace NexFlowSaude.Api.Modules.Pacientes.Application.DTOs;

public sealed class PacienteFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
