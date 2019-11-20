using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciadorDeTarefas.Migrations
{
    public partial class Update_Tarefa_AddCampoConcluida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Concluida",
                table: "tbTarefa",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Concluida",
                table: "tbTarefa");
        }
    }
}
