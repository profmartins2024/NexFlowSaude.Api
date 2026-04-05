namespace NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;

public sealed class RelatorioResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }

}
