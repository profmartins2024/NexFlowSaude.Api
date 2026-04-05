using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Notificacoes.Application.DTOs;
using NexFlowSaude.Api.Modules.Notificacoes.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Notificacoes.Presentation.Controllers;

[ApiController]
[Route("api/notificacoes")]
public sealed class NotificacoesController : ControllerBase
{
    private readonly INotificacaoService _service;

    public NotificacoesController(INotificacaoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificacaoResponseDto>>> Listar(CancellationToken cancellationToken)
    {
        return Ok(await _service.ListarAsync(cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<NotificacaoResponseDto>> Criar([FromBody] NotificacaoRequestDto request, CancellationToken cancellationToken)
    {
        return Ok(await _service.CriarAsync(request, cancellationToken));
    }
}
