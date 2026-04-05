namespace NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;

public sealed class AtualizarFaturamentoDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
