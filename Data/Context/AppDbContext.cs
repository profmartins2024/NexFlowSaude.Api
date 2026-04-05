using Microsoft.EntityFrameworkCore;
using NexFlowSaude.Api.Modules.Agendamentos.Domain.Entities;
using NexFlowSaude.Api.Modules.Auth.Domain.Entities;
using NexFlowSaude.Api.Modules.Chat.Domain.Entities;
using NexFlowSaude.Api.Modules.Estoque.Domain.Entities;
using NexFlowSaude.Api.Modules.Faturamento.Domain.Entities;
using NexFlowSaude.Api.Modules.Financeiro.Domain.Entities;
using NexFlowSaude.Api.Modules.Ia.Domain.Entities;
using NexFlowSaude.Api.Modules.Interoperabilidade.Domain.Entities;
using NexFlowSaude.Api.Modules.Notificacoes.Domain.Entities;
using NexFlowSaude.Api.Modules.Pacientes.Domain.Entities;
using NexFlowSaude.Api.Modules.Relatorios.Domain.Entities;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;

namespace NexFlowSaude.Api.Data.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    // Auth
    public DbSet<UsuarioAutenticacao> UsuariosAutenticacao { get; set; }

    public DbSet<Agendamento> Agendamentos { get; set; }
    public DbSet<LancamentoFinanceiro> LancamentosFinanceiros { get; set; }
    public DbSet<Fatura> Faturas { get; set; }
    public DbSet<ItemEstoque> ItensEstoque { get; set; }
    public DbSet<HistoricoIa> HistoricosIa { get; set; }
    public DbSet<Notificacao> Notificacoes { get; set; }
    public DbSet<Conversa> Conversas { get; set; }
    public DbSet<MensagemChat> MensagensChat { get; set; }
    public DbSet<ParticipanteConversa> ParticipantesConversa { get; set; }
    public DbSet<IntegracaoExterna> IntegracoesExternas { get; set; }
    public DbSet<FilaIntegracao> FilasIntegracao { get; set; }
    public DbSet<Relatorio> Relatorios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}