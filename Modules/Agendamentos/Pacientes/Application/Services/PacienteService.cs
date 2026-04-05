using NexFlowSaude.Api.Modules.Pacientes.Application.DTOs;
using NexFlowSaude.Api.Modules.Pacientes.Application.Interfaces;
using NexFlowSaude.Api.Modules.Pacientes.Domain.Entities;
using NexFlowSaude.Api.Modules.Pacientes.Domain.Interfaces;

namespace NexFlowSaude.Api.Modules.Pacientes.Application.Services;

public sealed class PacienteService : IPacienteService
{
    private readonly IPacienteRepository _repository;

    public PacienteService(IPacienteRepository repository)
    {
        _repository = repository;
    }

    public async Task<PacienteResponseDto> CriarAsync(PacienteRequestDto request, CancellationToken cancellationToken = default)
    {
        var entidade = new Paciente
        {
            Nome = request.Nome,
            Observacao = request.Observacao
        };

        await _repository.AdicionarAsync(entidade, cancellationToken);

        return new PacienteResponseDto
        {
            Id = entidade.Id,
            Nome = entidade.Nome,
            Observacao = entidade.Observacao,
            CriadoEm = entidade.CriadoEm
        };
    }

    public async Task<IEnumerable<PacienteResponseDto>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var lista = await _repository.ListarAsync(cancellationToken);

        return lista.Select(x => new PacienteResponseDto
        {
            Id = x.Id,
            Nome = x.Nome,
            Observacao = x.Observacao,
            CriadoEm = x.CriadoEm
        });
    }
}
