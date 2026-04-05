using NexFlowSaude.Api.Modules.Chat.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Chat.Application.Interfaces;

public interface IChatService
{
    Task<ConversaResponseDto> CriarConversaAsync(ConversaRequestDto request, CancellationToken cancellationToken = default);
    Task<MensagemChatResponseDto> EnviarMensagemAsync(MensagemChatRequestDto request, CancellationToken cancellationToken = default);
}
