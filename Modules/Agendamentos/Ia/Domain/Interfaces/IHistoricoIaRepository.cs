using NexFlowSaude.Api.Modules.Ia.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Ia.Domain.Interfaces;

public interface IHistoricoIaRepository
{
    Task AdicionarAsync(HistoricoIa entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<HistoricoIa>> ListarAsync(CancellationToken cancellationToken = default);
}
