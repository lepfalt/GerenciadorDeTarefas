using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Infraestrutura.Mappings
{
	public class MapTarefa : IEntityTypeConfiguration<Tarefa>
	{
		public void Configure(EntityTypeBuilder<Tarefa> builder)
		{
			builder
				.ToTable("tbTarefa");

			builder
				.Property(t => t.Codigo)
				.HasColumnName("Codigo")
				.IsRequired(true);

			builder
				.HasKey(t => t.Codigo)
				.HasName("pkTarefa");

			builder
				.Property(t => t.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(80)")
				.HasMaxLength(80)
				.IsRequired(true);

			builder
				.HasIndex(u => u.Nome)
				.HasName("ixTarefaNome")
				.IsUnique(true);

			builder
				.Property(t => t.Descricao)
				.HasColumnName("Descricao")
				.HasColumnType("varchar(5000)")
				.HasMaxLength(5000)
				.IsRequired(true);

			builder
				.Property(t => t.Data)
				.HasColumnName("Data")
				.IsRequired(true);

			builder
				.Property(t => t.Concluida)
				.HasColumnName("Concluida")
				.IsRequired(true);
		}
	}
}
