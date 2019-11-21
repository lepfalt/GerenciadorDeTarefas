using System;

namespace GerenciadorDeTarefas.Models
{
	public class Tarefa : Entity
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public bool Concluida { get; set; }

		public Guid CodigoUsuario { get; private set; }
		public virtual Usuario Usuario { get; private set; }

		public Tarefa(string nome, string descricao, DateTime data, bool concluida, Guid codigoUsuario)
		{
			Nome = nome;
			Descricao = descricao;
			Data = data;
			Concluida = concluida;
			CodigoUsuario = codigoUsuario;
		}

		public Tarefa Incluir(Usuario usuario)
		{
			Usuario = usuario;
			return this;
		}
	}
}