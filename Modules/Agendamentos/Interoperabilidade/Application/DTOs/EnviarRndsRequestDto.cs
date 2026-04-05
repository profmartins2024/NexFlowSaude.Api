namespace NexFlowSaude.Api.Modules.Interoperabilidade.Application.DTOs;

public sealed class EnviarRndsRequestDto
{
    public string TipoRecurso { get; set; } = string.Empty;
    public string Payload { get; set; } = string.Empty;
}
