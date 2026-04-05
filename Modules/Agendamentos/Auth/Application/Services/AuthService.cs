using NexFlowSaude.Api.Modules.Auth.Application.DTOs;
using NexFlowSaude.Api.Modules.Auth.Application.Interfaces;
using NexFlowSaude.Api.Modules.Auth.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Auth.Application.Services;

public sealed class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepository;
    private readonly ISenhaService _senhaService;
    private readonly ITokenService _tokenService;

    public AuthService(
        IAuthRepository authRepository,
        ISenhaService senhaService,
        ITokenService tokenService)
    {
        _authRepository = authRepository;
        _senhaService = senhaService;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDto> LoginAsync(
        LoginRequestDto request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
            throw new InvalidOperationException("Requisição inválida.");

        if (string.IsNullOrWhiteSpace(request.LoginOuEmail))
            throw new InvalidOperationException("Login ou e-mail é obrigatório.");

        if (string.IsNullOrWhiteSpace(request.Senha))
            throw new InvalidOperationException("Senha é obrigatória.");

        var loginOuEmail = request.LoginOuEmail.Trim().ToLowerInvariant();

        var usuario = await _authRepository.ObterPorLoginOuEmailAsync(loginOuEmail, cancellationToken);

        if (usuario is null)
            throw new UnauthorizedAccessException("Credenciais inválidas.");

        if (!usuario.Ativo)
            throw new UnauthorizedAccessException("Usuário inativo.");

        var senhaValida = _senhaService.Verificar(request.Senha, usuario.SenhaHash);

        if (!senhaValida)
            throw new UnauthorizedAccessException("Credenciais inválidas.");

        var accessToken = _tokenService.GerarAccessToken(usuario);
        var refreshToken = _tokenService.GerarRefreshToken();

        await _authRepository.SalvarRefreshTokenAsync(usuario.Id, refreshToken, cancellationToken);

        return new LoginResponseDto
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            TokenType = "Bearer",
            ExpiresIn = 900,
            UsuarioId = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email,
            Login = usuario.Login
        };
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(
        RefreshTokenRequestDto request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
            throw new InvalidOperationException("Requisição inválida.");

        if (string.IsNullOrWhiteSpace(request.RefreshToken))
            throw new InvalidOperationException("Refresh token é obrigatório.");

        var refreshToken = request.RefreshToken.Trim();

        var usuario = await _authRepository.ObterPorRefreshTokenAsync(refreshToken, cancellationToken);

        if (usuario is null)
            throw new UnauthorizedAccessException("Refresh token inválido ou expirado.");

        if (!usuario.Ativo)
            throw new UnauthorizedAccessException("Usuário inativo.");

        var novoAccessToken = _tokenService.GerarAccessToken(usuario);
        var novoRefreshToken = _tokenService.GerarRefreshToken();

        await _authRepository.SubstituirRefreshTokenAsync(
            usuario.Id,
            refreshToken,
            novoRefreshToken,
            cancellationToken);

        return new LoginResponseDto
        {
            AccessToken = novoAccessToken,
            RefreshToken = novoRefreshToken,
            TokenType = "Bearer",
            ExpiresIn = 900,
            UsuarioId = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Email = usuario.Email,
            Login = usuario.Login
        };
    }

    public async Task AlterarSenhaAsync(
        Guid usuarioId,
        AlterarSenhaRequestDto request,
        CancellationToken cancellationToken = default)
    {
        if (usuarioId == Guid.Empty)
            throw new InvalidOperationException("Usuário inválido.");

        if (request is null)
            throw new InvalidOperationException("Requisição inválida.");

        if (string.IsNullOrWhiteSpace(request.SenhaAtual))
            throw new InvalidOperationException("A senha atual é obrigatória.");

        if (string.IsNullOrWhiteSpace(request.NovaSenha))
            throw new InvalidOperationException("A nova senha é obrigatória.");

        if (string.IsNullOrWhiteSpace(request.ConfirmarNovaSenha))
            throw new InvalidOperationException("A confirmação da nova senha é obrigatória.");

        if (request.NovaSenha != request.ConfirmarNovaSenha)
            throw new InvalidOperationException("A confirmação da nova senha não confere.");

        if (request.SenhaAtual == request.NovaSenha)
            throw new InvalidOperationException("A nova senha deve ser diferente da senha atual.");

        ValidarForcaSenha(request.NovaSenha);

        var usuario = await _authRepository.ObterPorIdAsync(usuarioId, cancellationToken);

        if (usuario is null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        if (!usuario.Ativo)
            throw new UnauthorizedAccessException("Usuário inativo.");

        var senhaAtualValida = _senhaService.Verificar(request.SenhaAtual, usuario.SenhaHash);

        if (!senhaAtualValida)
            throw new UnauthorizedAccessException("Senha atual inválida.");

        usuario.SenhaHash = _senhaService.GerarHash(request.NovaSenha);
        usuario.AtualizadoEm = DateTime.UtcNow;

        await _authRepository.AtualizarUsuarioAsync(usuario, cancellationToken);
    }

    public async Task EsqueciSenhaAsync(
        EsqueciSenhaRequestDto request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
            throw new InvalidOperationException("Requisição inválida.");

        if (string.IsNullOrWhiteSpace(request.Email))
            throw new InvalidOperationException("O e-mail é obrigatório.");

        var email = request.Email.Trim().ToLowerInvariant();

        var usuario = await _authRepository.ObterPorLoginOuEmailAsync(email, cancellationToken);

        if (usuario is null)
            return;

        if (!usuario.Ativo)
            return;

        var tokenRedefinicao = _tokenService.GerarRefreshToken();

        await _authRepository.SalvarTokenRedefinicaoSenhaAsync(
            usuario.Id,
            tokenRedefinicao,
            DateTime.UtcNow.AddMinutes(30),
            cancellationToken);

        // Aqui depois vamos plugar envio real de e-mail.
    }

    public async Task RedefinirSenhaAsync(
        RedefinirSenhaRequestDto request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
            throw new InvalidOperationException("Requisição inválida.");

        if (string.IsNullOrWhiteSpace(request.Token))
            throw new InvalidOperationException("O token é obrigatório.");

        if (string.IsNullOrWhiteSpace(request.NovaSenha))
            throw new InvalidOperationException("A nova senha é obrigatória.");

        if (string.IsNullOrWhiteSpace(request.ConfirmarNovaSenha))
            throw new InvalidOperationException("A confirmação da nova senha é obrigatória.");

        if (request.NovaSenha != request.ConfirmarNovaSenha)
            throw new InvalidOperationException("A confirmação da nova senha não confere.");

        ValidarForcaSenha(request.NovaSenha);

        var token = request.Token.Trim();

        var redefinicao = await _authRepository.ObterRedefinicaoSenhaPorTokenAsync(token, cancellationToken);

        if (redefinicao is null)
            throw new UnauthorizedAccessException("Token inválido ou expirado.");

        if (redefinicao.Utilizado)
            throw new UnauthorizedAccessException("Token inválido ou expirado.");

        if (redefinicao.ExpiraEm < DateTime.UtcNow)
            throw new UnauthorizedAccessException("Token inválido ou expirado.");

        var usuario = await _authRepository.ObterPorIdAsync(redefinicao.UsuarioId, cancellationToken);

        if (usuario is null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        usuario.SenhaHash = _senhaService.GerarHash(request.NovaSenha);
        usuario.AtualizadoEm = DateTime.UtcNow;

        redefinicao.Utilizado = true;
        redefinicao.UtilizadoEm = DateTime.UtcNow;

        await _authRepository.AtualizarSenhaEConsumirTokenAsync(usuario, redefinicao, cancellationToken);
    }

    private static void ValidarForcaSenha(string senha)
    {
        if (senha.Length < 12)
            throw new InvalidOperationException("A senha deve ter no mínimo 12 caracteres.");

        if (!senha.Any(char.IsUpper))
            throw new InvalidOperationException("A senha deve conter ao menos uma letra maiúscula.");

        if (!senha.Any(char.IsLower))
            throw new InvalidOperationException("A senha deve conter ao menos uma letra minúscula.");

        if (!senha.Any(char.IsDigit))
            throw new InvalidOperationException("A senha deve conter ao menos um número.");

        if (!senha.Any(c => !char.IsLetterOrDigit(c)))
            throw new InvalidOperationException("A senha deve conter ao menos um caractere especial.");
    }
}