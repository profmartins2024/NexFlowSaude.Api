using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Auth.Application.DTOs;
using NexFlowSaude.Api.Modules.Auth.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Auth.Presentation.Controllers;

[ApiController]
[Route("api/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestDto request,
        CancellationToken cancellationToken)
    {
        var response = await _authService.LoginAsync(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenRequestDto request,
        CancellationToken cancellationToken)
    {
        var response = await _authService.RefreshTokenAsync(request, cancellationToken);
        return Ok(response);
    }

    [Authorize]
    [HttpPost("alterar-senha")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AlterarSenha(
        [FromBody] AlterarSenhaRequestDto request,
        CancellationToken cancellationToken)
    {
        var usuarioId = ObterUsuarioIdToken();

        await _authService.AlterarSenhaAsync(usuarioId, request, cancellationToken);

        return NoContent();
    }

    [HttpPost("esqueci-senha")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> EsqueciSenha(
        [FromBody] EsqueciSenhaRequestDto request,
        CancellationToken cancellationToken)
    {
        await _authService.EsqueciSenhaAsync(request, cancellationToken);

        return Ok(new
        {
            mensagem = "Se o e-mail existir, enviaremos as instruções para redefinição de senha."
        });
    }

    [HttpPost("redefinir-senha")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> RedefinirSenha(
        [FromBody] RedefinirSenhaRequestDto request,
        CancellationToken cancellationToken)
    {
        await _authService.RedefinirSenhaAsync(request, cancellationToken);

        return NoContent();
    }

    private Guid ObterUsuarioIdToken()
    {
        var sub = User.FindFirstValue(ClaimTypes.NameIdentifier)
                  ?? User.FindFirstValue("sub")
                  ?? User.FindFirstValue(ClaimTypes.Sid);

        if (string.IsNullOrWhiteSpace(sub))
            throw new UnauthorizedAccessException("Token inválido.");

        if (!Guid.TryParse(sub, out var usuarioId))
            throw new UnauthorizedAccessException("Token inválido.");

        return usuarioId;
    }
}