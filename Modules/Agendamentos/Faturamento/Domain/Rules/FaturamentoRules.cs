namespace NexFlowSaude.Api.Modules.Faturamento.Domain.Rules;

public static class FaturamentoRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
