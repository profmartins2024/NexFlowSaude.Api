using NexFlowSaude.Api.Modules.Ia.Application.DTOs;
using NexFlowSaude.Api.Modules.Ia.Application.Interfaces;
using NexFlowSaude.Api.Modules.Ia.Domain.Entities;
using NexFlowSaude.Api.Modules.Ia.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Ia.Application.Services;

public sealed class IaService : IIaService
{
    private readonly IHistoricoIaRepository _repository;

    public IaService(IHistoricoIaRepository repository)
    {
        _repository = repository;
    }

    public async Task<PerguntaIaResponseDto> PerguntarAsync(PerguntaIaRequestDto request, CancellationToken cancellationToken = default)
    {
        var historico = new HistoricoIa
        {
            Pergunta = request.Pergunta,
            Resposta = "Resposta inicial da IA.",
            Contexto = request.Contexto
        };

        await _repository.AdicionarAsync(historico, cancellationToken);

        return new PerguntaIaResponseDto
        {
            Resposta = historico.Resposta
        };
    }
}
