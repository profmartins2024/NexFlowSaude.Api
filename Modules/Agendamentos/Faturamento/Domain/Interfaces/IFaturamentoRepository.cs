using NexFlowSaude.Api.Modules.Faturamento.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Faturamento.Domain.Interfaces;

public interface IFaturamentoRepository
{
    Task AdicionarAsync(Fatura entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<Fatura>> ListarAsync(CancellationToken cancellationToken = default);
}
