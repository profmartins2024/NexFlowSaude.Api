namespace NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;

public sealed class AtualizarAgendamentoDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
