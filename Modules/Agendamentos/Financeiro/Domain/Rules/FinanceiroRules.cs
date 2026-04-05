namespace NexFlowSaude.Api.Modules.Financeiro.Domain.Rules;

public static class FinanceiroRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
