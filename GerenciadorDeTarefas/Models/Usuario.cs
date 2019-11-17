using GerenciadorDeTarefas.Enums;
using System;

namespace GerenciadorDeTarefas.Models
{
	public class Usuario : Entity
	{
		public string Nome { get; private set; }
		public string Email { get; private set; }
		public EPermissao Permissao { get; private set; }
		public string Senha { get; private set; }

		public Usuario(string nome, string email, EPermissao permissao, string senha)
		{
			Nome = nome;
			Email = email;
			Permissao = permissao;
			Senha = senha;
		}
	}
}