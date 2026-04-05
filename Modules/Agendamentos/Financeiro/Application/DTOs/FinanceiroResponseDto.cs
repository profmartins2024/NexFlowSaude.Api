namespace NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;

public sealed class FinanceiroResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }

}
