using NexFlowSaude.Api.Modules.Agendamentos.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Agendamentos.Domain.Interfaces;

public interface IAgendamentoRepository
{
    Task AdicionarAsync(Agendamento entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<Agendamento>> ListarAsync(CancellationToken cancellationToken = default);
}
