using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Infraestrutura.Mappings
{
	public class MapUsuario : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder
				.ToTable("tbUsuario");

			builder
				.Property(u => u.Codigo)
				.HasColumnName("Codigo")
				.IsRequired(true);

			builder
				.HasKey(u => u.Codigo)
				.HasName("pkUsuario");

			builder
				.Property(u => u.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(80)")
				.HasMaxLength(80)
				.IsRequired(true);

			builder
				.HasIndex(u => u.Nome)
				.HasName("ixUsuarioNome")
				.IsUnique(true);

			builder
				.Property(u => u.Email)
				.HasColumnName("Email")
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired(true);

			builder
				.Property(u => u.Permissao)
				.HasColumnName("Permissao")
				.IsRequired(true);

			builder
				.Property(u => u.Senha)
				.HasColumnName("Senha")
				.HasColumnType("varchar(50)")
				.HasMaxLength(50)
				.IsRequired(true);
		}
	}
}
