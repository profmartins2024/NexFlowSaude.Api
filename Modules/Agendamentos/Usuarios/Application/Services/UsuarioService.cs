using FluentValidation;
using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;
using NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Usuarios.Application.Services;

public sealed class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IValidator<UsuarioRequestDto> _usuarioValidator;
    private readonly ISenhaService _senhaService;

    public UsuarioService(
        IUsuarioRepository usuarioRepository,
        IValidator<UsuarioRequestDto> usuarioValidator,
        ISenhaService senhaService)
    {
        _usuarioRepository = usuarioRepository;
        _usuarioValidator = usuarioValidator;
        _senhaService = senhaService;
    }

    public async Task<UsuarioResponseDto> CadastrarAsync(
        UsuarioRequestDto request,
        CancellationToken cancellationToken = default)
    {
        var validacao = await _usuarioValidator.ValidateAsync(request, cancellationToken);

        if (!validacao.IsValid)
            throw new ValidationException(validacao.Errors);

        var emailNormalizado = NormalizarEmail(request.Email);
        var loginNormalizado = NormalizarLogin(request.Login);

        if (await _usuarioRepository.ExisteEmailAsync(emailNormalizado, cancellationToken))
            throw new InvalidOperationException("Já existe um usuário com este e-mail.");

        if (await _usuarioRepository.ExisteLoginAsync(loginNormalizado, cancellationToken))
            throw new InvalidOperationException("Já existe um usuário com este login.");

        var senhaHash = _senhaService.GerarHash(request.Senha);

        var usuario = new Usuario
        {
            Id = Guid.NewGuid(),
            NomeCompleto = request.NomeCompleto.Trim(),
            Email = emailNormalizado,
            Login = loginNormalizado,
            SenhaHash = senhaHash,
            Telefone = string.IsNullOrWhiteSpace(request.Telefone) ? null : request.Telefone.Trim(),
            Cargo = string.IsNullOrWhiteSpace(request.Cargo) ? null : request.Cargo.Trim(),
            Ativo = request.Ativo,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = null
        };

        await _usuarioRepository.AdicionarAsync(usuario, cancellationToken);
        await _usuarioRepository.SalvarAlteracoesAsync(cancellationToken);

        return MapearParaResponse(usuario);
    }

    public async Task<UsuarioResponseDto> AtualizarAsync(
        AtualizarUsuarioDto request,
        CancellationToken cancellationToken = default)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(request.Id, cancellationToken);

        if (usuario is null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        var emailNormalizado = NormalizarEmail(request.Email);
        var loginNormalizado = NormalizarLogin(request.Login);

        var emailEmUso = await _usuarioRepository.ExisteEmailAsync(emailNormalizado, request.Id, cancellationToken);
        if (emailEmUso)
            throw new InvalidOperationException("Já existe um usuário com este e-mail.");

        var loginEmUso = await _usuarioRepository.ExisteLoginAsync(loginNormalizado, request.Id, cancellationToken);
        if (loginEmUso)
            throw new InvalidOperationException("Já existe um usuário com este login.");

        usuario.NomeCompleto = request.NomeCompleto.Trim();
        usuario.Email = emailNormalizado;
        usuario.Login = loginNormalizado;
        usuario.Telefone = string.IsNullOrWhiteSpace(request.Telefone) ? null : request.Telefone.Trim();
        usuario.Cargo = string.IsNullOrWhiteSpace(request.Cargo) ? null : request.Cargo.Trim();
        usuario.Ativo = request.Ativo;
        usuario.AtualizadoEm = DateTime.UtcNow;

        _usuarioRepository.Atualizar(usuario);
        await _usuarioRepository.SalvarAlteracoesAsync(cancellationToken);

        return MapearParaResponse(usuario);
    }

    public async Task<UsuarioResponseDto?> ObterPorIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id, cancellationToken);

        if (usuario is null)
            return null;

        return MapearParaResponse(usuario);
    }

    public async Task<IReadOnlyCollection<UsuarioResponseDto>> ListarAsync(
        UsuarioFiltroDto filtro,
        CancellationToken cancellationToken = default)
    {
        filtro ??= new UsuarioFiltroDto();

        if (filtro.Pagina <= 0)
            filtro.Pagina = 1;

        if (filtro.TamanhoPagina <= 0)
            filtro.TamanhoPagina = 10;

        if (filtro.TamanhoPagina > 100)
            filtro.TamanhoPagina = 100;

        var usuarios = await _usuarioRepository.ListarAsync(filtro, cancellationToken);

        return usuarios
            .Select(MapearParaResponse)
            .ToList()
            .AsReadOnly();
    }

    public async Task<bool> RemoverAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var usuario = await _usuarioRepository.ObterPorIdAsync(id, cancellationToken);

        if (usuario is null)
            return false;

        _usuarioRepository.Remover(usuario);
        await _usuarioRepository.SalvarAlteracoesAsync(cancellationToken);

        return true;
    }

    public Task<bool> ExisteEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        var emailNormalizado = NormalizarEmail(email);
        return _usuarioRepository.ExisteEmailAsync(emailNormalizado, cancellationToken);
    }

    public Task<bool> ExisteLoginAsync(
        string login,
        CancellationToken cancellationToken = default)
    {
        var loginNormalizado = NormalizarLogin(login);
        return _usuarioRepository.ExisteLoginAsync(loginNormalizado, cancellationToken);
    }

    private static UsuarioResponseDto MapearParaResponse(Usuario usuario)
    {
        return new UsuarioResponseDto
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email,
            Login = usuario.Login,
            Telefone = usuario.Telefone,
            Cargo = usuario.Cargo,
            Ativo = usuario.Ativo,
            CriadoEm = usuario.CriadoEm,
            AtualizadoEm = usuario.AtualizadoEm
        };
    }

    private static string NormalizarEmail(string email)
    {
        return email.Trim().ToLowerInvariant();
    }

    private static string NormalizarLogin(string login)
    {
        return login.Trim().ToLowerInvariant();
    }
}