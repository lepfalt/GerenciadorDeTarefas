using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciadorDeTarefas.Models;
using GerenciadorDeTarefas.Infraestrutura;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace GerenciadorDeTarefas.Controllers
{
	public class HomeController : Controller
	{
		protected readonly GerenciadorContext Db;
		protected readonly DbSet<Usuario> DbSet;
		protected readonly DbConnection dbConnection;

		public HomeController()
		{
			Db = new GerenciadorContext();
			DbSet = Db.Set<Usuario>();

			//Dapper
			dbConnection = Db.Database.GetDbConnection();
			
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(string Email, string Senha)
		{
			var usuario = Db.Usuarios
						   .Where(u => u.Email == Email && u.Senha == Senha)
						   .FirstOrDefault();

			if (usuario == null)
				return View();

			return View("~/Views/Usuario/Index.cshtml");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View();
		}
	}
}
