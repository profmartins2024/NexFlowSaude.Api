namespace NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;

public sealed class FinanceiroRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
