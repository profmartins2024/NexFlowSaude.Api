using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFlowSaude.Api.Modules.Auth.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Auth.Infrastructure.Configurations;

public sealed class TokenRedefinicaoSenhaConfiguration : IEntityTypeConfiguration<TokenRedefinicaoSenha>
{
    public void Configure(EntityTypeBuilder<TokenRedefinicaoSenha> builder)
    {
        builder.ToTable("TokensRedefinicaoSenha");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.UsuarioId)
            .IsRequired();

        builder.Property(x => x.Token)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.ExpiraEm)
            .IsRequired();

        builder.Property(x => x.Utilizado)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(x => x.UtilizadoEm)
            .IsRequired(false);

        builder.Property(x => x.CriadoEm)
            .IsRequired();

        builder.HasIndex(x => x.Token)
            .IsUnique();

        builder.HasIndex(x => x.UsuarioId);

        builder.HasIndex(x => x.ExpiraEm);

        builder.HasIndex(x => x.Utilizado);
    }
}