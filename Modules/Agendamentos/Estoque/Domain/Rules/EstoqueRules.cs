namespace NexFlowSaude.Api.Modules.Estoque.Domain.Rules;

public static class EstoqueRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
