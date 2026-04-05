using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Interfaces;

public interface IIntegracaoExternaRepository
{
    Task AdicionarAsync(IntegracaoExterna entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<IntegracaoExterna>> ListarAsync(CancellationToken cancellationToken = default);
}
