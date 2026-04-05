namespace NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;

public sealed class RelatorioFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
