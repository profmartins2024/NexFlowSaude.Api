using Microsoft.AspNetCore.Mvc;
using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;
using NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Usuarios.Presentation.Controllers;

[ApiController]
[Route("api/usuarios")]
public sealed class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UsuarioResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Cadastrar(
        [FromBody] UsuarioRequestDto request,
        CancellationToken cancellationToken)
    {
        var usuario = await _usuarioService.CadastrarAsync(request, cancellationToken);

        return CreatedAtAction(
            nameof(ObterPorId),
            new { id = usuario.Id },
            usuario);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UsuarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar(
        [FromRoute] Guid id,
        [FromBody] AtualizarUsuarioDto request,
        CancellationToken cancellationToken)
    {
        request.Id = id;

        var usuario = await _usuarioService.AtualizarAsync(request, cancellationToken);

        return Ok(usuario);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(UsuarioResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var usuario = await _usuarioService.ObterPorIdAsync(id, cancellationToken);

        if (usuario is null)
            return NotFound(new { mensagem = "Usuário não encontrado." });

        return Ok(usuario);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyCollection<UsuarioResponseDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Listar(
        [FromQuery] UsuarioFiltroDto filtro,
        CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioService.ListarAsync(filtro, cancellationToken);

        return Ok(usuarios);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remover(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var removido = await _usuarioService.RemoverAsync(id, cancellationToken);

        if (!removido)
            return NotFound(new { mensagem = "Usuário não encontrado." });

        return NoContent();
    }

    [HttpGet("existe-email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ExisteEmail(
        [FromQuery] string email,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(email))
            return BadRequest(new { mensagem = "O e-mail é obrigatório." });

        var existe = await _usuarioService.ExisteEmailAsync(email, cancellationToken);

        return Ok(new { existe });
    }

    [HttpGet("existe-login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ExisteLogin(
        [FromQuery] string login,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(login))
            return BadRequest(new { mensagem = "O login é obrigatório." });

        var existe = await _usuarioService.ExisteLoginAsync(login, cancellationToken);

        return Ok(new { existe });
    }
}