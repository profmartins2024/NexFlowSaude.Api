namespace NexFlowSaude.Api.Modules.Notificacoes.Application.DTOs;

public sealed class NotificacaoRequestDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Mensagem { get; set; } = string.Empty;
    public Guid? UsuarioId { get; set; }
}
