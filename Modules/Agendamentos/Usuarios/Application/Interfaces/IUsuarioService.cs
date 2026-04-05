using NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;

public interface IUsuarioService
{
    Task<UsuarioResponseDto> CadastrarAsync(UsuarioRequestDto request, CancellationToken cancellationToken = default);
    Task<UsuarioResponseDto> AtualizarAsync(AtualizarUsuarioDto request, CancellationToken cancellationToken = default);
    Task<UsuarioResponseDto?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<UsuarioResponseDto>> ListarAsync(UsuarioFiltroDto filtro, CancellationToken cancellationToken = default);
    Task<bool> RemoverAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExisteEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<bool> ExisteLoginAsync(string login, CancellationToken cancellationToken = default);
}