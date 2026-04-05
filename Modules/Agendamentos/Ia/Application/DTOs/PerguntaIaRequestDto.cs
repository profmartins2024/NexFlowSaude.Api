namespace NexFlowSaude.Api.Modules.Ia.Application.DTOs;

public sealed class PerguntaIaRequestDto
{
    public string Pergunta { get; set; } = string.Empty;
    public string? Contexto { get; set; }
    public Guid? UsuarioId { get; set; }
}
