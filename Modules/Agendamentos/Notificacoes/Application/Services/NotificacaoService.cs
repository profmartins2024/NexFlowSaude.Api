using NexFlowSaude.Api.Modules.Notificacoes.Application.DTOs;
using NexFlowSaude.Api.Modules.Notificacoes.Application.Interfaces;
using NexFlowSaude.Api.Modules.Notificacoes.Domain.Entities;
using NexFlowSaude.Api.Modules.Notificacoes.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Notificacoes.Application.Services;

public sealed class NotificacaoService : INotificacaoService
{
    private readonly INotificacaoRepository _repository;

    public NotificacaoService(INotificacaoRepository repository)
    {
        _repository = repository;
    }

    public async Task<NotificacaoResponseDto> CriarAsync(NotificacaoRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new Notificacao
        {
            Titulo = request.Titulo,
            Mensagem = request.Mensagem,
            UsuarioId = request.UsuarioId
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new NotificacaoResponseDto
        {
            Id = entidade.Id,
            Titulo = entidade.Titulo,
            Mensagem = entidade.Mensagem,
            Lida = entidade.Lida
        };
    }

    public async Task<IEnumerable<NotificacaoResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var dados = await _repository.ListarAsync(cancellationToken);
        return dados.Select(x => new NotificacaoResponseDto
        {
            Id = x.Id,
            Titulo = x.Titulo,
            Mensagem = x.Mensagem,
            Lida = x.Lida
        });
    }
}
