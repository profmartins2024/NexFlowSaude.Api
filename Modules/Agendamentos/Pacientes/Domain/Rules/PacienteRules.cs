namespace NexFlowSaude.Api.Modules.Pacientes.Domain.Rules;

public static class PacienteRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
