namespace NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;

public sealed class FinanceiroFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
