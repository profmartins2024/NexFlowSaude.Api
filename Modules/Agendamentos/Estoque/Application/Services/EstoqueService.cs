using NexFlowSaude.Api.Modules.Estoque.Application.DTOs;
using NexFlowSaude.Api.Modules.Estoque.Application.Interfaces;
using NexFlowSaude.Api.Modules.Estoque.Domain.Entities;
using NexFlowSaude.Api.Modules.Estoque.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Estoque.Application.Services;

public sealed class EstoqueService : IEstoqueService
{
    private readonly IEstoqueRepository _repository;

    public EstoqueService(IEstoqueRepository repository)
    {
        _repository = repository;
    }

    public async Task<EstoqueResponseDto> CriarAsync(EstoqueRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new ItemEstoque
        {
            Nome = request.Nome,
            Observacao = request.Observacao
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new EstoqueResponseDto
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Observacao = entidade.Observacao,
            CriadoEm = entidade.CriadoEm
        };
    }

    public async Task<IEnumerable<EstoqueResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repository.ListarAsync(cancellationToken);

        return lista.Select(x => new EstoqueResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Observacao = x.Observacao,
            CriadoEm = x.CriadoEm
        });
    }
}
