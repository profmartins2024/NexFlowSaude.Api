using NexFlowSaude.Api.Modules.Pacientes.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Pacientes.Domain.Interfaces;

public interface IPacienteRepository
{
    Task AdicionarAsync(Paciente entidade, CancellationToken cancellationToken = default);
    Task<IEnumerable<Paciente>> ListarAsync(CancellationToken cancellationToken = default);
}
