using Biblioteca.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Data.Mappings;

public class EmprestimoMapping : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("Emprestimo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.UsuarioId)
            .IsRequired(true)
            .HasColumnType("BIGINT");

        builder.Property(x => x.LivroId)
            .IsRequired(true)
            .HasColumnType("BIGINT");

        builder.Property(x => x.DataEmprestimo)
            .IsRequired(false);

        builder.Property(x => x.DataDevolucao)
            .IsRequired(false);
    }
}
