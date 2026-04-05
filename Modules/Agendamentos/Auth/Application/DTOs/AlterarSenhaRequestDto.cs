namespace NexFlowSaude.Api.Modules.Auth.Application.DTOs;

public sealed class AlterarSenhaRequestDto
{
    public string SenhaAtual { get; set; } = string.Empty;
    public string NovaSenha { get; set; } = string.Empty;
    public string ConfirmarNovaSenha { get; set; } = string.Empty;
}