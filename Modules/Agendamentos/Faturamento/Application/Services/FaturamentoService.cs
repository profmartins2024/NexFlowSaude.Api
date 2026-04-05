using NexFlowSaude.Api.Modules.Faturamento.Application.DTOs;
using NexFlowSaude.Api.Modules.Faturamento.Application.Interfaces;
using NexFlowSaude.Api.Modules.Faturamento.Domain.Entities;
using NexFlowSaude.Api.Modules.Faturamento.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Faturamento.Application.Services;

public sealed class FaturamentoService : IFaturamentoService
{
    private readonly IFaturamentoRepository _repository;

    public FaturamentoService(IFaturamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<FaturamentoResponseDto> CriarAsync(FaturamentoRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new Fatura
        {
            Nome = request.Nome,
            Observacao = request.Observacao
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new FaturamentoResponseDto
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Observacao = entidade.Observacao,
            CriadoEm = entidade.CriadoEm
        };
    }

    public async Task<IEnumerable<FaturamentoResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repository.ListarAsync(cancellationToken);

        return lista.Select(x => new FaturamentoResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Observacao = x.Observacao,
            CriadoEm = x.CriadoEm
        });
    }
}
