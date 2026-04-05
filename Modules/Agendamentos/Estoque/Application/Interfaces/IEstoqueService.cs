using NexFlowSaude.Api.Modules.Estoque.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Estoque.Application.Interfaces;

public interface IEstoqueService
{
    Task<EstoqueResponseDto> CriarAsync(EstoqueRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<EstoqueResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
