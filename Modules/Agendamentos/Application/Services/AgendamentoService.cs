using NexFlowSaude.Api.Modules.Agendamentos.Application.DTOs;
using NexFlowSaude.Api.Modules.Agendamentos.Application.Interfaces;
using NexFlowSaude.Api.Modules.Agendamentos.Domain.Entities;
using NexFlowSaude.Api.Modules.Agendamentos.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Agendamentos.Application.Services;

public sealed class AgendamentoService : IAgendamentoService
{
    private readonly IAgendamentoRepository _repository;

    public AgendamentoService(IAgendamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<AgendamentoResponseDto> CriarAsync(AgendamentoRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new Agendamento
        {
            Nome = request.Nome,
            Observacao = request.Observacao
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new AgendamentoResponseDto
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Observacao = entidade.Observacao,
            CriadoEm = entidade.CriadoEm
        };
    }

    public async Task<IEnumerable<AgendamentoResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repository.ListarAsync(cancellationToken);

        return lista.Select(x => new AgendamentoResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Observacao = x.Observacao,
            CriadoEm = x.CriadoEm
        });
    }
}
