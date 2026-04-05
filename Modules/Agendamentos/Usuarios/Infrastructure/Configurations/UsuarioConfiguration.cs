using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexFlowSaude.Api.Modules.Usuarios.Domain.Entities;

namespace NexFlowSaude.Api.Modules.Usuarios.Infrastructure.Configurations;

public sealed class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.NomeCompleto)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Login)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.SenhaHash)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.Telefone)
            .HasMaxLength(20);

        builder.Property(x => x.Cargo)
            .HasMaxLength(100);

        builder.Property(x => x.Ativo)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(x => x.CriadoEm)
            .IsRequired();

        builder.Property(x => x.AtualizadoEm)
            .IsRequired(false);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.HasIndex(x => x.Login)
            .IsUnique();

        builder.HasIndex(x => x.NomeCompleto);

        builder.HasIndex(x => x.Ativo);
    }
}