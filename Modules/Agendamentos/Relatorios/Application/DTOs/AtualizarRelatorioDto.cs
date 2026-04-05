namespace NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;

public sealed class AtualizarRelatorioDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
