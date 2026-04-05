using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Faturamento.Domain.Entities;
using NexFlowSaude.Api.Modules.Faturamento.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Faturamento.Infrastructure.Repositories;

public sealed class FaturamentoRepository : IFaturamentoRepository
{
    private readonly AppDbContext _context;

    public FaturamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Fatura entidade, CancellationToken cancellationToken = default)
    {
        await _context.Set<Fatura>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Fatura>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Fatura>()
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEm)
            .ToListAsync(cancellationToken);
    }
}
