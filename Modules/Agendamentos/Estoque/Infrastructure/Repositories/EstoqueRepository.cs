using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Estoque.Domain.Entities;
using NexFlowSaude.Api.Modules.Estoque.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Estoque.Infrastructure.Repositories;

public sealed class EstoqueRepository : IEstoqueRepository
{
    private readonly AppDbContext _context;

    public EstoqueRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(ItemEstoque entidade, CancellationToken cancellationToken = default)
    {
        await _context.Set<ItemEstoque>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ItemEstoque>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<ItemEstoque>()
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEm)
            .ToListAsync(cancellationToken);
    }
}
