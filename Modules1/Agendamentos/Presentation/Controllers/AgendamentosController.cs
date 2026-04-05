using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;
using NexFlowSaude.Api.Modules.Agendamentos.Application.Interfaces;
using NexFlowSaude.Api.Shared.Responses;

namespace NexFlowSaude.Api.Modules.Agendamentos.Presentation.Controllers;

[ApiController]
[Route("api/agendamentos")]
public sealed class AgendamentosController : ControllerBase
{
    private readonly IAgendamentoService _service;

    public AgendamentosController(IAgendamentoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<AgendamentoResponseDto>>>> Listar(CancellationToken cancellationToken)
    {
        var dados = await _service.ListarAsync(cancellationToken);
        return Ok(ApiResponse<IEnumerable<AgendamentoResponseDto>>.Ok(dados));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<AgendamentoResponseDto>>> Criar([FromBody] AgendamentoRequestDto request, CancellationToken cancellationToken)
    {
        var dados = await _service.CriarAsync(request, cancellationToken);
        return Ok(ApiResponse<AgendamentoResponseDto>.Ok(dados));
    }
}
