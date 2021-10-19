using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeNotas.App.Persistencia.Migrations
{
    public partial class ajustebasedatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodDepartamento",
                table: "Municipios");

            migrationBuilder.DropColumn(
                name: "NombreDepartamento",
                table: "Municipios");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Municipios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_DepartamentoId",
                table: "Municipios",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Departamentos_DepartamentoId",
                table: "Municipios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Departamentos_DepartamentoId",
                table: "Municipios");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Municipios_DepartamentoId",
                table: "Municipios");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Municipios");

            migrationBuilder.AddColumn<string>(
                name: "CodDepartamento",
                table: "Municipios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreDepartamento",
                table: "Municipios",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
