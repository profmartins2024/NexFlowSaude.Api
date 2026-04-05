using NexFlowSaude.Api.Modules.Auth.Domain.Entities;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Auth.Domain.Interfaces;

public interface IAuthRepository
{
    Task<Usuario?> ObterPorLoginOuEmailAsync(string loginOuEmail, CancellationToken cancellationToken = default);
    Task<Usuario?> ObterPorRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default);
    Task<Usuario?> ObterPorIdAsync(Guid usuarioId, CancellationToken cancellationToken = default);

    Task SalvarRefreshTokenAsync(Guid usuarioId, string refreshToken, CancellationToken cancellationToken = default);
    Task SubstituirRefreshTokenAsync(Guid usuarioId, string refreshTokenAtual, string novoRefreshToken, CancellationToken cancellationToken = default);

    Task AtualizarUsuarioAsync(Usuario usuario, CancellationToken cancellationToken = default);

    Task SalvarTokenRedefinicaoSenhaAsync(
        Guid usuarioId,
        string token,
        DateTime expiraEm,
        CancellationToken cancellationToken = default);

    Task<TokenRedefinicaoSenha?> ObterRedefinicaoSenhaPorTokenAsync(
        string token,
        CancellationToken cancellationToken = default);

    Task AtualizarSenhaEConsumirTokenAsync(
        Usuario usuario,
        TokenRedefinicaoSenha tokenRedefinicao,
        CancellationToken cancellationToken = default);
}