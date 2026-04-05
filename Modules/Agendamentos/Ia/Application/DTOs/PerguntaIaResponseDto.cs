namespace NexFlowSaude.Api.Modules.Ia.Application.DTOs;

public sealed class PerguntaIaResponseDto
{
    public string Resposta { get; set; } = string.Empty;
    public DateTime GeradoEm { get; set; } = DateTime.UtcNow;
}
