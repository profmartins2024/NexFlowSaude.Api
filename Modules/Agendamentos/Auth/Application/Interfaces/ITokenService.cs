using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Auth.Application.Interfaces;

public interface ITokenService
{
    string GerarAccessToken(Usuario usuario);
    string GerarRefreshToken();
}