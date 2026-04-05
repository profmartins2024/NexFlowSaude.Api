using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Auth.Domain.Entities;

public sealed class UsuarioAutenticacao : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
}
