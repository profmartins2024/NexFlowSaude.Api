namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class LoginRequestDto
{
    public string LoginOuEmail { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}