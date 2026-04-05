namespace NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;

public sealed class UsuarioRequestDto
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string ConfirmarSenha { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Cargo { get; set; }
    public bool Ativo { get; set; } = true;
}