using NexFlowSaude.Api.Modules.Notificacoes.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Notificacoes.Domain.Interfaces;

public interface INotificacaoRepository
{
    Task AdicionarAsync(Notificacao entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<Notificacao>> ListarAsync(CancellationToken cancellationToken = default);
}
