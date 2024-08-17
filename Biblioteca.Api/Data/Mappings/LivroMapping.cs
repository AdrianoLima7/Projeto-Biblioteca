using Biblioteca.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Api.Data.Mappings;

public class LivroMapping : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livro");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .IsRequired(true)
            .HasMaxLength(200)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Autor)
            .IsRequired(true)
            .HasMaxLength(100)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.ISBN)
            .IsRequired(false)
            .HasMaxLength(13)
            .HasColumnType("NVARCHAR");

        builder.Property(x => x.Copias)
            .IsRequired()
            .HasColumnType("BIGINT");

        builder.Property(x => x.AnoLancamento)
            .IsRequired()
            .HasColumnType("INT");
    }
}
