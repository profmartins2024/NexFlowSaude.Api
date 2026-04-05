namespace NexFlowSaude.Api.Modules.Notificacoes.Application.DTOs;

public sealed class NotificacaoResponseDto
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public bool Lida { get; set; }
}
