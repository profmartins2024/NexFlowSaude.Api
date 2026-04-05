using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Ia.Domain.Entities;
using NexFlowSaude.Api.Modules.Ia.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Ia.Infrastructure.Repositories;

public sealed class HistoricoIaRepository : IHistoricoIaRepository
{
    private readonly AppDbContext _context;

    public HistoricoIaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(HistoricoIa entidade, CancellationToken cancellationToken = default)
    {
        await _context.HistoricosIa.AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<HistoricoIa>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.HistoricosIa.AsNoTracking().OrderByDescending(x => x.CriadoEm).ToListAsync(cancellationToken);
    }
}
