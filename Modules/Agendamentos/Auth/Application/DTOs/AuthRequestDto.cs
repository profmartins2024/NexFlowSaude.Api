namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class AuthRequestDto
{
    public string Nome { get; set; } = string.Empty;
    public string? Observacao { get; set; }
}
