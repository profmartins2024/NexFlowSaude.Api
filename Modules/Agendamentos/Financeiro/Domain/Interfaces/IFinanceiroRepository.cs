using NexFlowSaude.Api.Modules.Financeiro.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Financeiro.Domain.Interfaces;

public interface IFinanceiroRepository
{
    Task AdicionarAsync(LancamentoFinanceiro entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<LancamentoFinanceiro>> ListarAsync(CancellationToken cancellationToken = default);
}
