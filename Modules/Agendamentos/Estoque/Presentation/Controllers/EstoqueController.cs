using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Estoque.Application.DTOs;
using NexFlowSaude.Api.Modules.Estoque.Application.Interfaces;
using NexFlowSaude.Api.Shared.Responses;

namespace NexFlowSaude.Api.Modules.Estoque.Presentation.Controllers;

[ApiController]
[Route("api/estoque")]
public sealed class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _service;

    public EstoqueController(IEstoqueService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<EstoqueResponseDto>>>> Listar(CancellationToken cancellationToken)
    {
        var dados = await _service.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IEnumerable<EstoqueResponseDto>>.Ok(dados));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<EstoqueResponseDto>>> Criar([FromBody] EstoqueRequestDto request, CancellationToken cancellationToken)
    {
        var dados = await _service.CriarAsync(request, cancellationToken);
        return Ok(ApiResponse<EstoqueResponseDto>.Ok(dados));
    }
}
