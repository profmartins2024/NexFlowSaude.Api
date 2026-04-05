namespace NexFlowSaude.Api.Modules.Estoque.Application.DTOs;

public sealed class EstoqueFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
