using NexFlowSaude.Api.Modules.Pacientes.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Pacientes.Application.Interfaces;

public interface IPacienteService
{
    Task<PacienteResponseDto> CriarAsync(PacienteRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<PacienteResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
