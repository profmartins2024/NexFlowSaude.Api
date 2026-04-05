namespace NexFlowSaude.Api.Modules.Estoque.Application.DTOs;

public sealed class EstoqueRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
