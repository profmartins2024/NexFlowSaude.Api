using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;
using NexFlowSaude.Api.Modules.Faturamento.Application.Interfaces;
using NexFlowSaude.Api.Shared.Responses;

namespace NexFlowSaude.Api.Modules.Faturamento.Presentation.Controllers;

[ApiController]
[Route("api/faturamento")]
public sealed class FaturamentoController : ControllerBase
{
    private readonly IFaturamentoService _service;

    public FaturamentoController(IFaturamentoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FaturamentoResponseDto>>>> Listar(CancellationToken cancellationToken)
    {
        var dados = await _service.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IEnumerable<FaturamentoResponseDto>>.Ok(dados));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<FaturamentoResponseDto>>> Criar([FromBody] FaturamentoRequestDto request, CancellationToken cancellationToken)
    {
        var dados = await _service.CriarAsync(request, cancellationToken);
        return Ok(ApiResponse<FaturamentoResponseDto>.Ok(dados));
    }
}
