using GerenciadorDeTarefas.Infraestrutura.Mappings;
using GerenciadorDeTarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeTarefas.Infraestrutura
{
	public class GerenciadorContext : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
		//public DbSet<Tarefa> Tarefas { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new MapUsuario());
			//modelBuilder.ApplyConfiguration(new MapTarefa());

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
			optionsBuilder.EnableSensitiveDataLogging();
		}
	}
}

