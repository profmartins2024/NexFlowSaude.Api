using NexFlowSaude.Api.Modules.Relatorios.Application.DTOs;
using NexFlowSaude.Api.Modules.Relatorios.Application.Interfaces;
using NexFlowSaude.Api.Modules.Relatorios.Domain.Entities;
using NexFlowSaude.Api.Modules.Relatorios.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Relatorios.Application.Services;

public sealed class RelatorioService : IRelatorioService
{
    private readonly IRelatorioRepository _repository;

    public RelatorioService(IRelatorioRepository repository)
    {
        _repository = repository;
    }

    public async Task<RelatorioResponseDto> CriarAsync(RelatorioRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new Relatorio
        {
            Nome = request.Nome,
            Observacao = request.Observacao
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new RelatorioResponseDto
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Observacao = entidade.Observacao,
            CriadoEm = entidade.CriadoEm
        };
    }

    public async Task<IEnumerable<RelatorioResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repository.ListarAsync(cancellationToken);

        return lista.Select(x => new RelatorioResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Observacao = x.Observacao,
            CriadoEm = x.CriadoEm
        });
    }
}
