namespace NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;

public sealed class RelatorioRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
