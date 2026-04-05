using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Relatorios.Domain.Entities;
using NexFlowSaude.Api.Modules.Relatorios.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Relatorios.Infrastructure.Repositories;

public sealed class RelatorioRepository : IRelatorioRepository
{
    private readonly AppDbContext _context;

    public RelatorioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Relatorio entidade, CancellationToken cancellationToken = default)
    {
        await _context.Set<Relatorio>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Relatorio>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Relatorio>()
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEm)
            .ToListAsync(cancellationToken);
    }
}
