using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Agendamentos.Domain.Entities;
using NexFlowSaude.Api.Modules.Agendamentos.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Agendamentos.Infrastructure.Repositories;

public sealed class AgendamentoRepository : IAgendamentoRepository
{
    private readonly AppDbContext _context;

    public AgendamentoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Agendamento entidade, CancellationToken cancellationToken = default)
    {
        await _context.Set<Agendamento>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Agendamento>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Agendamento>()
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEm)
            .ToListAsync(cancellationToken);
    }
}
