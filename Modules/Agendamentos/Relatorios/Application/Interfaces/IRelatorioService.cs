using NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Relatorios.Application.Interfaces;

public interface IRelatorioService
{
    Task<RelatorioResponseDto> CriarAsync(RelatorioRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<RelatorioResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
