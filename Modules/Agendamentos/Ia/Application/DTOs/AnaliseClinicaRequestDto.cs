namespace NexFlowSaude.Api.Modules.Ia.Application.DTOs;

public sealed class AnaliseClinicaRequestDto
{
    public string Conteudo { get; set; } = string.Empty;
    public Guid? PacienteId { get; set; }
}
