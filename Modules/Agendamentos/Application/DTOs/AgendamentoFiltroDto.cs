namespace NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;

public sealed class AgendamentoFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
