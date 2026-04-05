namespace NexFlowSaude.Api.Modules.Auth.Domain.Entities;

public sealed class TokenRedefinicaoSenha
{
    public Guid Id { get; set; }

    public Guid UsuarioId { get; set; }

    public string Token { get; set; } = string.Empty;

    public DateTime ExpiraEm { get; set; }

    public bool Utilizado { get; set; }

    public DateTime? UtilizadoEm { get; set; }

    public DateTime CriadoEm { get; set; }
}