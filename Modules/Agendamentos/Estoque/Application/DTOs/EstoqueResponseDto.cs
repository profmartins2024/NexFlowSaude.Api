namespace NexFlowSaude.Api.Modules.Estoque.Application.DTOs;

public sealed class EstoqueResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }

}
