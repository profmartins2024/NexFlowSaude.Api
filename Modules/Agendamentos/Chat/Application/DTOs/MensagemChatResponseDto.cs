namespace NexFlowSaude.Api.Modules.Chat.Application.DTOs;

public sealed class MensagemChatResponseDto
{
    public Guid Id { get; set; }
    public Guid ConversaId { get; set; }
    public Guid RemetenteId { get; set; }
    public string Conteudo { get; set; } = string.Empty;
    public DateTime EnviadaEm { get; set; }
}
