namespace NexFlowSaude.Api.Modules.Auth.Domain.Rules;

public static class AuthRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
