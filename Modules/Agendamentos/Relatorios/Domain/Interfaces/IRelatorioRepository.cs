using NexFlowSaude.Api.Modules.Relatorios.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Relatorios.Domain.Interfaces;

public interface IRelatorioRepository
{
    Task AdicionarAsync(Relatorio entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<Relatorio>> ListarAsync(CancellationToken cancellationToken = default);
}
