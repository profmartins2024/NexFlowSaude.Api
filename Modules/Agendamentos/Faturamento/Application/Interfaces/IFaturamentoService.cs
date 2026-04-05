using NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Faturamento.Application.Interfaces;

public interface IFaturamentoService
{
    Task<FaturamentoResponseDto> CriarAsync(FaturamentoRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<FaturamentoResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
