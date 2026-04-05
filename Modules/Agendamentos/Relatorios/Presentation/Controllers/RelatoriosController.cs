using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;
using NexFlowSaude.Api.Modules.Relatorios.Application.Interfaces;
using NexFlowSaude.Api.Shared.Responses;

namespace NexFlowSaude.Api.Modules.Relatorios.Presentation.Controllers;

[ApiController]
[Route("api/relatorios")]
public sealed class RelatoriosController : ControllerBase
{
    private readonly IRelatorioService _service;

    public RelatoriosController(IRelatorioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<RelatorioResponseDto>>>> Listar(CancellationToken cancellationToken)
    {
        var dados = await _service.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IEnumerable<RelatorioResponseDto>>.Ok(dados));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<RelatorioResponseDto>>> Criar([FromBody] RelatorioRequestDto request, CancellationToken cancellationToken)
    {
        var dados = await _service.CriarAsync(request, cancellationToken);
        return Ok(ApiResponse<RelatorioResponseDto>.Ok(dados));
    }
}
