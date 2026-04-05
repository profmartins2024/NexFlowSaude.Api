namespace NexFlowSaude.Api.Modules.Chat.Application.DTOs;

public sealed class MensagemChatRequestDto
{
    public Guid ConversaId { get; set; }
    public Guid RemetenteId { get; set; }
    public string Conteudo { get; set; } = string.Empty;
}
