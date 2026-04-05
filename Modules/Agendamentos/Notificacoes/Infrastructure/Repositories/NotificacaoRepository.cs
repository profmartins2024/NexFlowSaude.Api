using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Notificacoes.Domain.Entities;
using NexFlowSaude.Api.Modules.Notificacoes.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Notificacoes.Infrastructure.Repositories;

public sealed class NotificacaoRepository : INotificacaoRepository
{
    private readonly AppDbContext _context;

    public NotificacaoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Notificacao entidade, CancellationToken cancellationToken = default)
    {
        await _context.Notificacoes.AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Notificacao>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Notificacoes.AsNoTracking().OrderByDescending(x => x.CriadoEm).ToListAsync(cancellationToken);
    }
}
