namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class AuthResponseDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
    public DateTime CriadoEm { get; set; }
}
