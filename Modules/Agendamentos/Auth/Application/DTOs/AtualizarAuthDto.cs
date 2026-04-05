namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class AtualizarAuthDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public bool Ativo { get; set; } = true;
}
