namespace NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;

public sealed class AgendamentoRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }

}
