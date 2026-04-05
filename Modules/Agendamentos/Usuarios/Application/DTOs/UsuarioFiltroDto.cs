namespace NexFlowSaude.Api.Modules.Usuarios.Application.DTOs;

public sealed class UsuarioFiltroDto
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Login { get; set; }
    public bool? Ativo { get; set; }

    // Paginação
    public int Pagina { get; set; } = 1;
    public int TamanhoPagina { get; set; } = 10;

    // Ordenação
    public string? OrdenarPor { get; set; } = "NomeCompleto";
    public bool OrdenarDesc { get; set; } = false;
}