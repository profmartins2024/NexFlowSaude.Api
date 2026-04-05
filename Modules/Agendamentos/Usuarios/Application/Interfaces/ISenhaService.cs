namespace NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;

public interface ISenhaService
{
    string GerarHash(string senha);
    bool Verificar(string senha, string senhaHash);
}