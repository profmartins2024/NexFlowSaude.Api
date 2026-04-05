using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;
using NexFlowSaude.Api.Modules.Financeiro.Application.Interfaces;
using NexFlowSaude.Api.Shared.Responses;

namespace NexFlowSaude.Api.Modules.Financeiro.Presentation.Controllers;

[ApiController]
[Route("api/financeiro")]
public sealed class FinanceiroController : ControllerBase
{
    private readonly IFinanceiroService _service;

    public FinanceiroController(IFinanceiroService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<FinanceiroResponseDto>>>> Listar(CancellationToken cancellationToken)
    {
        var dados = await _service.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IEnumerable<FinanceiroResponseDto>>.Ok(dados));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<FinanceiroResponseDto>>> Criar([FromBody] FinanceiroRequestDto request, CancellationToken cancellationToken)
    {
        var dados = await _service.CriarAsync(request, cancellationToken);
        return Ok(ApiResponse<FinanceiroResponseDto>.Ok(dados));
    }
}
