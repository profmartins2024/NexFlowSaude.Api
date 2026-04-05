using Isopoh.Cryptography.Argon2;
using NexFlowSaude.Api.Modules.Usuarios.Application.Interfaces;

namespace NexFlowSaude.Api.Modules.Usuarios.Application.Services;

public sealed class SenhaService : ISenhaService
{
    public string GerarHash(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
            throw new ArgumentException("Senha inválida.");

        return Argon2.Hash(senha);
    }

    public bool Verificar(string senha, string senhaHash)
    {
        if (string.IsNullOrWhiteSpace(senha))
            return false;

        if (string.IsNullOrWhiteSpace(senhaHash))
            return false;

        return Argon2.Verify(senhaHash, senha);
    }
}