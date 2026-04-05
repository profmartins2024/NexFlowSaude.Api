namespace NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;

public sealed class FaturamentoResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }

}
