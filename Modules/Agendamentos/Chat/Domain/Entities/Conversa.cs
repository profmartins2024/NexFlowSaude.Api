using NexFlowSaude.Api.Shared.Common;

namespace NexFlowSaude.Api.Modules.Chat.Domain.Entities;

public sealed class Conversa : BaseEntity
{
    public string Titulo { get; set; } = string.Empty;
}
