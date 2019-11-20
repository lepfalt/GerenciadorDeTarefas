using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeTarefas.Migrations
{
    public partial class Add_Tarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbTarefa",
                columns: table => new
                {
                    Codigo = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(5000)", maxLength: 5000, nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pkTarefa", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "ixTarefaNome",
                table: "tbTarefa",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbTarefa");
        }
    }
}
