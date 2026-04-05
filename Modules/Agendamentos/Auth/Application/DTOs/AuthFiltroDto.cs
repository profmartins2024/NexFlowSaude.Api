namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class AuthFiltroDto
{
    public string? Termo { get; set; }
    public bool SomenteAtivos { get; set; } = true;
}
