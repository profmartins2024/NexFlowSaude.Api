using NexFlowSaude.Api.Modules.Auth.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Auth.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken = default);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request, CancellationToken cancellationToken = default);

    Task AlterarSenhaAsync(Guid usuarioId, AlterarSenhaRequestDto request, CancellationToken cancellationToken = default);
    Task EsqueciSenhaAsync(EsqueciSenhaRequestDto request, CancellationToken cancellationToken = default);
    Task RedefinirSenhaAsync(RedefinirSenhaRequestDto request, CancellationToken cancellationToken = default);
}