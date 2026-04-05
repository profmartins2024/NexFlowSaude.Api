using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Chat.Domain.Entities;
using NexFlowSaude.Api.Modules.Chat.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Chat.Infrastructure.Repositories;

public sealed class ChatRepository : IChatRepository
{
    private readonly AppDbContext _context;

    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarConversaAsync(Conversa entidade, CancellationToken cancellationToken = default)
    {
        await _context.Conversas.AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AdicionarMensagemAsync(MensagemChat entidade, CancellationToken cancellationToken = default)
    {
        await _context.MensagensChat.AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
