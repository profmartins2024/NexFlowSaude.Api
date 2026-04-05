using NexFlowSaude.Api.Modules.Estoque.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Estoque.Domain.Interfaces;

public interface IEstoqueRepository
{
    Task AdicionarAsync(ItemEstoque entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<ItemEstoque>> ListarAsync(CancellationToken cancellationToken = default);
}
