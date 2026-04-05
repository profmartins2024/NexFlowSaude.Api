using NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Financeiro.Application.Interfaces;

public interface IFinanceiroService
{
    Task<FinanceiroResponseDto> CriarAsync(FinanceiroRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<FinanceiroResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
