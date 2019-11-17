using System;

namespace GerenciadorDeTarefas.Models
{
	public class Tarefa : Entity
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public DateTime Data { get; set; }

		public Tarefa(string nome, string descricao, DateTime data)
		{
			Nome = nome;
			Descricao = descricao;
			Data = data;
		}
	}
}