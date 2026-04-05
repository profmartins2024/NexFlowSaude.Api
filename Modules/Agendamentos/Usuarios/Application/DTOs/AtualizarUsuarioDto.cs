namespace NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;

public sealed class AtualizarUsuarioDto
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string? Telefone { get; set; }
    public string? Cargo { get; set; }
    public bool Ativo { get; set; }
}