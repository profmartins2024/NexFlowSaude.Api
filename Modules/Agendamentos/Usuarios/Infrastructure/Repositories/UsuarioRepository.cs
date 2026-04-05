using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Data.Context;
using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Interfaces;


namespace NexFlowSaude.Api.Modules.Usuarios.Infrastructure.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken = default)
    {
        await _context.Set<Usuario>().AddAsync(usuario, cancellationToken);
    }

    public async Task<Usuario?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<Usuario>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Usuario>> ListarAsync(UsuarioFiltroDto filtro, CancellationToken cancellationToken = default)
    {
        var query = _context
            .Set<Usuario>()
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filtro.Nome))
        {
            var nome = filtro.Nome.Trim().ToLower();
            query = query.Where(x => x.NomeCompleto.ToLower().Contains(nome));
        }

        if (!string.IsNullOrWhiteSpace(filtro.Email))
        {
            var email = filtro.Email.Trim().ToLower();
            query = query.Where(x => x.Email.ToLower().Contains(email));
        }

        if (!string.IsNullOrWhiteSpace(filtro.Login))
        {
            var login = filtro.Login.Trim().ToLower();
            query = query.Where(x => x.Login.ToLower().Contains(login));
        }

        if (filtro.Ativo.HasValue)
        {
            query = query.Where(x => x.Ativo == filtro.Ativo.Value);
        }

        query = AplicarOrdenacao(query, filtro);

        var skip = (filtro.Pagina - 1) * filtro.TamanhoPagina;

        var usuarios = await query
            .Skip(skip)
            .Take(filtro.TamanhoPagina)
            .ToListAsync(cancellationToken);

        return usuarios.AsReadOnly();
    }

    public async Task<bool> ExisteEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<Usuario>()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<bool> ExisteEmailAsync(string email, Guid usuarioIdIgnorar, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<Usuario>()
            .AnyAsync(x => x.Email == email && x.Id != usuarioIdIgnorar, cancellationToken);
    }

    public async Task<bool> ExisteLoginAsync(string login, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<Usuario>()
            .AnyAsync(x => x.Login == login, cancellationToken);
    }

    public async Task<bool> ExisteLoginAsync(string login, Guid usuarioIdIgnorar, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<Usuario>()
            .AnyAsync(x => x.Login == login && x.Id != usuarioIdIgnorar, cancellationToken);
    }

    public void Atualizar(Usuario usuario)
    {
        _context.Set<Usuario>().Update(usuario);
    }

    public void Remover(Usuario usuario)
    {
        _context.Set<Usuario>().Remove(usuario);
    }

    public Task<int> SalvarAlteracoesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    private static IQueryable<Usuario> AplicarOrdenacao(IQueryable<Usuario> query, UsuarioFiltroDto filtro)
    {
        var ordenarPor = filtro.OrdenarPor?.Trim().ToLowerInvariant();

        return ordenarPor switch
        {
            "nome" or "nomecompleto" => filtro.OrdenarDesc
                ? query.OrderByDescending(x => x.NomeCompleto)
                : query.OrderBy(x => x.NomeCompleto),

            "email" => filtro.OrdenarDesc
                ? query.OrderByDescending(x => x.Email)
                : query.OrderBy(x => x.Email),

            "login" => filtro.OrdenarDesc
                ? query.OrderByDescending(x => x.Login)
                : query.OrderBy(x => x.Login),

            "ativo" => filtro.OrdenarDesc
                ? query.OrderByDescending(x => x.Ativo)
                : query.OrderBy(x => x.Ativo),

            "criadoem" => filtro.OrdenarDesc
                ? query.OrderByDescending(x => x.CriadoEm)
                : query.OrderBy(x => x.CriadoEm),

            _ => filtro.OrdenarDesc
                ? query.OrderByDescending(x => x.NomeCompleto)
                : query.OrderBy(x => x.NomeCompleto)
        };
    }
}