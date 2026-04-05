using NexFlowSaude.Api.Modules.Financeiro.Application.DTOs;
using NexFlowSaude.Api.Modules.Financeiro.Application.Interfaces;
using NexFlowSaude.Api.Modules.Financeiro.Domain.Entities;
using NexFlowSaude.Api.Modules.Financeiro.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Financeiro.Application.Services;

public sealed class FinanceiroService : IFinanceiroService
{
    private readonly IFinanceiroRepository _repository;

    public FinanceiroService(IFinanceiroRepository repository)
    {
        _repository = repository;
    }

    public async Task<FinanceiroResponseDto> CriarAsync(FinanceiroRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new LancamentoFinanceiro
        {
            Nome = request.Nome,
            Observacao = request.Observacao
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new FinanceiroResponseDto
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Observacao = entidade.Observacao,
            CriadoEm = entidade.CriadoEm
        };
    }

    public async Task<IEnumerable<FinanceiroResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repository.ListarAsync(cancellationToken);

        return lista.Select(x => new FinanceiroResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Observacao = x.Observacao,
            CriadoEm = x.CriadoEm
        });
    }
}
