using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Pacientes.Domain.Entities;
using NexFlowSaude.Api.Modules.Pacientes.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Pacientes.Infrastructure.Repositories;

public sealed class PacienteRepository : IPacienteRepository
{
    private readonly AppDbContext _context;

    public PacienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Paciente entidade, CancellationToken cancellationToken = default)
    {
        await _context.Set<Paciente>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Paciente>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<Paciente>()
            .AsNoTracking()
            .OrderByDescending(x => x.CriadoEm)
            .ToListAsync(cancellationToken);
    }
}
