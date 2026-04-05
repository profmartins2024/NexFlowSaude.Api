using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Ia.Application.DTOs;
using NexFlowSaude.Api.Modules.Ia.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Ia.Presentation.Controllers;

[ApiController]
[Route("api/ia")]
public sealed class IaController : ControllerBase
{
    private readonly IIaService _service;

    public IaController(IIaService service)
    {
        _service = service;
    }

    [HttpPost("perguntar")]
    public async Task<ActionResult<PerguntaIaResponseDto>> Perguntar([FromBody] PerguntaIaRequestDto request, CancellationToken cancellationToken)
    {
        return Ok(await _service.PerguntarAsync(request, cancellationToken));
    }
}
