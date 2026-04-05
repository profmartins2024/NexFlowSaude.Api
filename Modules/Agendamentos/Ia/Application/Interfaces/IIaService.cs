using NexFlowSaude.Api.Modules.Ia.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Ia.Application.Interfaces;

public interface IIaService
{
    Task<PerguntaIaResponseDto> PerguntarAsync(PerguntaIaRequestDto request, CancellationToken cancellationToken = default);
}
