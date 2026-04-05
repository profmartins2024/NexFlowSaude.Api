using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Auth.Domain.Entities;
using NexFlowSaude.Api.Modules.Auth.Domain.Interfaces;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;


namespace NexFlowSaude.Api.Modules.Auth.Infrastructure.Repositories;

public sealed class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> ObterPorLoginOuEmailAsync(
        string loginOuEmail,
        CancellationToken cancellationToken = default)
    {
        var valor = loginOuEmail.Trim().ToLower();

        return await _context
            .Set<Usuario>()
            .FirstOrDefaultAsync(x =>
                x.Email.ToLower() == valor ||
                x.Login.ToLower() == valor,
                cancellationToken);
    }

    public async Task<Usuario?> ObterPorRefreshTokenAsync(
        string refreshToken,
        CancellationToken cancellationToken = default)
    {
        // ⚠️ TEMPORÁRIO (vamos substituir depois)
        return await _context
            .Set<Usuario>()
            .FirstOrDefaultAsync(x => x.Login == refreshToken, cancellationToken);
    }

    public async Task<Usuario?> ObterPorIdAsync(
        Guid usuarioId,
        CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<Usuario>()
            .FirstOrDefaultAsync(x => x.Id == usuarioId, cancellationToken);
    }

    public async Task SalvarRefreshTokenAsync(
        Guid usuarioId,
        string refreshToken,
        CancellationToken cancellationToken = default)
    {
        var usuario = await ObterPorIdAsync(usuarioId, cancellationToken);

        if (usuario is null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        // ⚠️ TEMPORÁRIO
        usuario.Login = refreshToken;

        _context.Update(usuario);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SubstituirRefreshTokenAsync(
        Guid usuarioId,
        string refreshTokenAtual,
        string novoRefreshToken,
        CancellationToken cancellationToken = default)
    {
        var usuario = await ObterPorIdAsync(usuarioId, cancellationToken);

        if (usuario is null)
            throw new KeyNotFoundException("Usuário não encontrado.");

        // ⚠️ TEMPORÁRIO
        usuario.Login = novoRefreshToken;

        _context.Update(usuario);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AtualizarUsuarioAsync(
        Usuario usuario,
        CancellationToken cancellationToken = default)
    {
        _context.Update(usuario);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task SalvarTokenRedefinicaoSenhaAsync(
        Guid usuarioId,
        string token,
        DateTime expiraEm,
        CancellationToken cancellationToken = default)
    {
        var entidade = new TokenRedefinicaoSenha
        {
            Id = Guid.NewGuid(),
            UsuarioId = usuarioId,
            Token = token,
            ExpiraEm = expiraEm,
            Utilizado = false,
            CriadoEm = DateTime.UtcNow
        };

        await _context.Set<TokenRedefinicaoSenha>().AddAsync(entidade, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TokenRedefinicaoSenha?> ObterRedefinicaoSenhaPorTokenAsync(
        string token,
        CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TokenRedefinicaoSenha>()
            .FirstOrDefaultAsync(x => x.Token == token, cancellationToken);
    }

    public async Task AtualizarSenhaEConsumirTokenAsync(
        Usuario usuario,
        TokenRedefinicaoSenha tokenRedefinicao,
        CancellationToken cancellationToken = default)
    {
        _context.Update(usuario);
        _context.Update(tokenRedefinicao);

        await _context.SaveChangesAsync(cancellationToken);
    }
}