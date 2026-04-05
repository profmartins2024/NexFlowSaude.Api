using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Interoperabilidade.Application.DTOs;
using NexFlowSaude.Api.Modules.Interoperabilidade.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Presentation.Controllers;

[ApiController]
[Route("api/interoperabilidade")]
public sealed class InteroperabilidadeController : ControllerBase
{
    private readonly IInteroperabilidadeService _service;

    public InteroperabilidadeController(IInteroperabilidadeService service)
    {
        _service = service;
    }

    [HttpPost("rnds")]
    public async Task<ActionResult<IntegracaoGovResponseDto>> EnviarRnds([FromBody] EnviarRndsRequestDto request, CancellationToken cancellationToken)
    {
        return Ok(await _service.EnviarRndsAsync(request, cancellationToken));
    }
}
