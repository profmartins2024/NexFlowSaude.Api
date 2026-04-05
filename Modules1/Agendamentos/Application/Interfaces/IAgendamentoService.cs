using NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Agendamentos.Application.Interfaces;

public interface IAgendamentoService
{
    Task<AgendamentoResponseDto> CriarAsync(AgendamentoRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<AgendamentoResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
