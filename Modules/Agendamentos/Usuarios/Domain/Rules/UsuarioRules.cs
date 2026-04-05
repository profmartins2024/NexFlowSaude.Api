namespace NexFlowSaude.Api.Modules.Usuarios.Domain.Rules;

public static class UsuarioRules
{
    public static bool NomeValido(string nome) => !string.IsNullOrWhiteSpace(nome);
}
