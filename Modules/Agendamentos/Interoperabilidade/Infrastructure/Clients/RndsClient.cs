namespace NexFlowSaude.Api.Modules.Interoperabilidade.Infrastructure.Clients;

public sealed class RndsClient
{
    public Task<string> EnviarAsync(string payload, CancellationToken cancellationToken = default)
    {
        return Task.FromResult("{\"status\":\"pendente\"}");
    }
}
