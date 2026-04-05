using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Chat.Application.DTOs;
using NexFlowSaude.Api.Modules.Chat.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Chat.Presentation.Controllers;

[ApiController]
[Route("api/chat")]
public sealed class ChatController : ControllerBase
{
    private readonly IChatService _service;

    public ChatController(IChatService service)
    {
        _service = service;
    }

    [HttpPost("conversas")]
    public async Task<ActionResult<ConversaResponseDto>> CriarConversa([FromBody] ConversaRequestDto request, CancellationToken cancellationToken)
    {
        return Ok(await _service.CriarConversaAsync(request, cancellationToken));
    }

    [HttpPost("mensagens")]
    public async Task<ActionResult<MensagemChatResponseDto>> EnviarMensagem([FromBody] MensagemChatRequestDto request, CancellationToken cancellationToken)
    {
        return Ok(await _service.EnviarMensagemAsync(request, cancellationToken));
    }
}
