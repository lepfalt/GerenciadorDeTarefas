using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeTarefas.Migrations
{
    public partial class Add_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbUsuario",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Permissao = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkUsuario", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "ixUsuarioNome",
                table: "tbUsuario",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbUsuario");
        }
    }
}
