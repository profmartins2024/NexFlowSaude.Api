using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Usuarios.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task AdicionarAsync(Usuario usuario, CancellationToken cancellationToken = default);
    Task<Usuario?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Usuario>> ListarAsync(UsuarioFiltroDto filtro, CancellationToken cancellationToken = default);

    Task<bool> ExisteEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> ExisteEmailAsync(string email, Guid usuarioIdIgnorar, CancellationToken cancellationToken = default);

    Task<bool> ExisteLoginAsync(string login, CancellationToken cancellationToken = default);
    Task<bool> ExisteLoginAsync(string login, Guid usuarioIdIgnorar, CancellationToken cancellationToken = default);

    void Atualizar(Usuario usuario);
    void Remover(Usuario usuario);

    Task<int> SalvarAlteracoesAsync(CancellationToken cancellationToken = default);
}