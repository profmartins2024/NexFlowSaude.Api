using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Financeiro.Domain.Entities;
using NexFlowSaude.Api.Modules.Financeiro.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Financeiro.Infrastructure.Repositories;

public sealed class FinanceiroRepository : IFinanceiroRepository
{
    private readonly AppDbContext _context;

    public FinanceiroRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(LancamentoFinanceiro entidade, CancellationToken cancellationToken = default)
    {
        await _context.Set<LancamentoFinanceiro>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<LancamentoFinanceiro>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<LancamentoFinanceiro>()
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEm)
            .ToListAsync(cancellationToken);
    }
}
