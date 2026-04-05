using NexFlowSaude.Api.Modules.Chat.Application.DTOs;
using NexFlowSaude.Api.Modules.Chat.Application.Interfaces;
using NexFlowSaude.Api.Modules.Chat.Domain.Entities;
using NexFlowSaude.Api.Modules.Chat.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Chat.Application.Services;

public sealed class ChatService : IChatService
{
    private readonly IChatRepository _repository;

    public ChatService(IChatRepository repository)
    {
        _repository = repository;
    }

    public async Task<ConversaResponseDto> CriarConversaAsync(ConversaRequestDto request, CancellationToken cancellationToken = default)
    {
        var conversa = new Conversa { Titulo = request.Titulo };
        await _repository.AdicionarConversaAsync(conversa, cancellationToken);

        return new ConversaResponseDto
        {
            Id = conversa.Id,
            Titulo = conversa.Titulo
        };
    }

    public async Task<MensagemChatResponseDto> EnviarMensagemAsync(MensagemChatRequestDto request, CancellationToken cancellationToken = default)
    {
        var mensagem = new MensagemChat
        {
            ConversaId = request.ConversaId,
            RemetenteId = request.RemetenteId,
            Conteudo = request.Conteudo,
            EnviadaEm = DateTime.UtcNow
        };

        await _repository.AdicionarMensagemAsync(mensagem, cancellationToken);

        return new MensagemChatResponseDto
        {
            Id = mensagem.Id,
            ConversaId = mensagem.ConversaId,
            RemetenteId = mensagem.RemetenteId,
            Conteudo = mensagem.Conteudo,
            EnviadaEm = mensagem.EnviadaEm
        };
    }
}
