namespace NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;

public sealed class FaturamentoFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
