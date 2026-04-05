using NexFlowSaude.Api.Modules.Notificacoes.Application.DTOs;

namespace NexFlowSaude.Api.Modules.Notificacoes.Application.Interfaces;

public interface INotificacaoService
{
    Task<NotificacaoResponseDto> CriarAsync(NotificacaoRequestDto request, CancellationToken cancellationToken = default);
    Task<IEnumerable<NotificacaoResponseDto>> ListarAsync(CancellationToken cancellationToken = default);
}
