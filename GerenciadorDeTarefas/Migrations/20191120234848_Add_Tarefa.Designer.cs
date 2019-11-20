﻿// <auto-generated />
using System;
using GerenciadorDeTarefas.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GerenciadorDeTarefas.Migrations
{
    [DbContext(typeof(GerenciadorContext))]
    [Migration("20191120234848_Add_Tarefa")]
    partial class Add_Tarefa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciadorDeTarefas.Models.Tarefa", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Codigo");

                    b.Property<DateTime>("Data")
                        .HasColumnName("Data");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("Descricao")
                        .HasColumnType("varchar(5000)")
                        .HasMaxLength(5000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.HasKey("Codigo")
                        .HasName("pkTarefa");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("ixTarefaNome");

                    b.ToTable("tbTarefa");
                });

            modelBuilder.Entity("GerenciadorDeTarefas.Models.Usuario", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Codigo");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(80)")
                        .HasMaxLength(80);

                    b.Property<int>("Permissao")
                        .HasColumnName("Permissao");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnName("Senha")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Codigo")
                        .HasName("pkUsuario");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("ixUsuarioNome");

                    b.ToTable("tbUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
