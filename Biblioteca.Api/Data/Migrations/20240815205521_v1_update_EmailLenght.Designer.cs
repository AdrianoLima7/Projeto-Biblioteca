﻿// <auto-generated />
using System;
using Biblioteca.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteca.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240815205521_v1_update_EmailLenght")]
    partial class v1_update_EmailLenght
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biblioteca.Core.Models.Emprestimo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataEmprestimo")
                        .HasColumnType("datetime2");

                    b.Property<long>("LivroId")
                        .HasColumnType("BIGINT");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("BIGINT");

                    b.HasKey("Id");

                    b.HasIndex("LivroId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimo", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Core.Models.Livro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AnoLancamento")
                        .HasColumnType("INT");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<long>("Copias")
                        .HasColumnType("BIGINT");

                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Livro", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Core.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<int>("LivrosPegos")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("Biblioteca.Core.Models.Emprestimo", b =>
                {
                    b.HasOne("Biblioteca.Core.Models.Livro", "Livro")
                        .WithMany("Emprestimos")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteca.Core.Models.Usuario", "Usuario")
                        .WithMany("Emprestimos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Biblioteca.Core.Models.Livro", b =>
                {
                    b.Navigation("Emprestimos");
                });

            modelBuilder.Entity("Biblioteca.Core.Models.Usuario", b =>
                {
                    b.Navigation("Emprestimos");
                });
#pragma warning restore 612, 618
        }
    }
}
