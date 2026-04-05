using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Entities;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Infrastructure.Repositories;

public sealed class IntegracaoExternaRepository : IIntegracaoExternaRepository
{
    private readonly AppDbContext _context;

    public IntegracaoExternaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(IntegracaoExterna entidade, CancellationToken cancellationToken = default)
    {
        await _context.IntegracoesExternas.AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<IntegracaoExterna>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.IntegracoesExternas.AsNoTracking().OrderByDescending(x => x.CriadoEm).ToListAsync(cancellationToken);
    }
}
