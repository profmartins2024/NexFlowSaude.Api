using NexFlowSaude.Api.Modules.Interoperabilidade.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Application.Interfaces;

public interface IInteroperabilidadeService
{
    Task<IntegracaoGovResponseDto> EnviarRndsAsync(EnviarRndsRequestDto request, CancellationToken cancellationToken = default);
}
