using NexFlowSaude.Api.Modules.Interoperabilidade.Application.DTOs;
using NexFlowSaude.Api.Modules.Interoperabilidade.Application.Interfaces;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Entities;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Enums;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Interoperabilidade.Application.Services;

public sealed class InteroperabilidadeService : IInteroperabilidadeService
{
    private readonly IIntegracaoExternaRepository _repository;

    public InteroperabilidadeService(IIntegracaoExternaRepository repository)
    {
        _repository = repository;
    }

    public async Task<IntegracaoGovResponseDto> EnviarRndsAsync(EnviarRndsRequestDto request, CancellationToken cancellationToken = default)
    {
        var integracao = new IntegracaoExterna
        {
            Sistema = SistemaExterno.Rnds,
            Operacao = request.TipoRecurso,
            PayloadEnviado = request.Payload,
            Status = StatusIntegracao.Pendente
        };

        await _repository.AdicionarAsync(integracao, cancellationToken);

        return new IntegracaoGovResponseDto
        {
            Id = integracao.Id,
            Sistema = integracao.Sistema.ToString(),
            Operacao = integracao.Operacao,
            Status = integracao.Status.ToString()
        };
    }
}
