namespace NexFlowSaude.Api.Modules.Relatorios.Domain.Rules;

public static class RelatorioRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
