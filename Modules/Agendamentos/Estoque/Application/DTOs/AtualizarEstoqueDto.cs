namespace NexFlowSaude.Api.Modules.Estoque.Application.DTOs;

public sealed class AtualizarEstoqueDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
