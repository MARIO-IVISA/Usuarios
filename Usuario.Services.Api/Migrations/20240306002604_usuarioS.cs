using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Usuario.Services.Api.Migrations
{
    public partial class usuarioS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilEnum",
                table: "Usuarios",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfilEnum",
                table: "Usuarios");
        }
    }
}
