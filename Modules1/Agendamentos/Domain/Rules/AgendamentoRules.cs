namespace NexFlowSaude.Api.Modules.Agendamentos.Domain.Rules;

public static class AgendamentoRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
