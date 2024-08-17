using Biblioteca.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Data.Mappings;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .IsRequired(true)
            .HasMaxLength(100)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Email)
            .IsRequired(false)
            .HasMaxLength(255)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.DataNascimento)
            .IsRequired(false);

        builder.Property(x => x.Telefone)
            .IsRequired(true)
            .HasMaxLength(15)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.LivrosPegos)
            .IsRequired()
            .HasColumnType("INT");
    }
}
