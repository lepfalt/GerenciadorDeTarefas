using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeTarefas.Migrations
{
    public partial class Update_Tarefa_AddCampoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CodigoUsuario",
                table: "tbTarefa",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ixTarefaCodigoUsuario",
                table: "tbTarefa",
                column: "CodigoUsuario");

            migrationBuilder.AddForeignKey(
                name: "fkTarefaUsuario",
                table: "tbTarefa",
                column: "CodigoUsuario",
                principalTable: "tbUsuario",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fkTarefaUsuario",
                table: "tbTarefa");

            migrationBuilder.DropIndex(
                name: "ixTarefaCodigoUsuario",
                table: "tbTarefa");

            migrationBuilder.DropColumn(
                name: "CodigoUsuario",
                table: "tbTarefa");
        }
    }
}
