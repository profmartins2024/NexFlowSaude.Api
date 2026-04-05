namespace NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;

public sealed class AgendamentoResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }

}
