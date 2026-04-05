namespace NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;

public sealed class FaturamentoRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
