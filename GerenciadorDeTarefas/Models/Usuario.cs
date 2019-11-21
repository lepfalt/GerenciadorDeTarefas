using GerenciadorDeTarefas.Enums;
using System;
using System.Collections.Generic;

namespace GerenciadorDeTarefas.Models
{
	public class Usuario : Entity
	{
		public string Nome { get; private set; }
		public string Email { get; private set; }
		public EPermissao Permissao { get; private set; }
		public string Senha { get; private set; }

		public virtual IEnumerable<Tarefa> Tarefas { get; private set; }

		public Usuario(string nome, string email, EPermissao permissao, string senha)
		{
			Nome = nome;
			Email = email;
			Permissao = permissao;
			Senha = senha;
		}

		public Usuario Incluir(IEnumerable<Tarefa> tarefas)
		{
			Tarefas = tarefas;
			return this;
		}
	}
}