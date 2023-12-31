﻿// <auto-generated />
using System;
using GerenciarArmazen.MeuContexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GerenciarArmazen.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230618125937_Usuario-Pedido")]
    partial class UsuarioPedido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GerenciarArmazen.Models.Armazenamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Armazenamento");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Medida");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Ingrediente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmazenamentoId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Validade")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ArmazenamentoId")
                        .IsUnique();

                    b.HasIndex("CategoriaId")
                        .IsUnique();

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<int>("PratoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double?>("Valor")
                        .HasColumnType("float")
                        .HasColumnName("Valor");

                    b.Property<int?>("mesa")
                        .HasColumnType("int")
                        .HasColumnName("Mesa");

                    b.HasKey("Id");

                    b.HasIndex("PratoId")
                        .IsUnique();

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IngredienteId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId")
                        .IsUnique();

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<bool>("Gerente")
                        .HasColumnType("bit")
                        .HasColumnName("Gerente");

                    b.Property<string>("Matricula")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Matricula");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Senha");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Ingrediente", b =>
                {
                    b.HasOne("GerenciarArmazen.Models.Armazenamento", "Armazenamento")
                        .WithOne("Ingrediente")
                        .HasForeignKey("GerenciarArmazen.Models.Ingrediente", "ArmazenamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciarArmazen.Models.Categoria", "Categoria")
                        .WithOne("Ingrediente")
                        .HasForeignKey("GerenciarArmazen.Models.Ingrediente", "CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Armazenamento");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Pedido", b =>
                {
                    b.HasOne("GerenciarArmazen.Models.Prato", "Prato")
                        .WithOne("Pedido")
                        .HasForeignKey("GerenciarArmazen.Models.Pedido", "PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GerenciarArmazen.Models.Usuario", "Usuario")
                        .WithOne("Pedido")
                        .HasForeignKey("GerenciarArmazen.Models.Pedido", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prato");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Prato", b =>
                {
                    b.HasOne("GerenciarArmazen.Models.Ingrediente", "Ingrediente")
                        .WithOne("Prato")
                        .HasForeignKey("GerenciarArmazen.Models.Prato", "IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Armazenamento", b =>
                {
                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Categoria", b =>
                {
                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Ingrediente", b =>
                {
                    b.Navigation("Prato");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Prato", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("GerenciarArmazen.Models.Usuario", b =>
                {
                    b.Navigation("Pedido");
                });
#pragma warning restore 612, 618
        }
    }
}
