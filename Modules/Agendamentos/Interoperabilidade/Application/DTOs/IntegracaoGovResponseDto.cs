namespace NexFlowSaude.Api.Modules.Interoperabilidade.Application.DTOs;

public sealed class IntegracaoGovResponseDto
{
    public Guid Id { get; set; }
    public string Sistema { get; set; } = string.Empty;
    public string Operacao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
