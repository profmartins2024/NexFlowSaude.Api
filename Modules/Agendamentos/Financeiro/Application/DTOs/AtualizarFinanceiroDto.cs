namespace NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;

public sealed class AtualizarFinanceiroDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
