namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class RefreshTokenRequestDto
{
    public string RefreshToken { get; set; } = string.Empty;
}