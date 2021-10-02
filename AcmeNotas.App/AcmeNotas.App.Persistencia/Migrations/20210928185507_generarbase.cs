using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeNotas.App.Persistencia.Migrations
{
    public partial class generarbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoEstudiante",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoFormador",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoTutor",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdE",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdF",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdT",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolPersonaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoEstudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodNotas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEstudiantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciclos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoFormador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTutor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodHorario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio1 = table.Column<int>(type: "int", nullable: false),
                    HoraFinal1 = table.Column<int>(type: "int", nullable: false),
                    Dia2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio2 = table.Column<int>(type: "int", nullable: false),
                    HoraFinal2 = table.Column<int>(type: "int", nullable: false),
                    Dia3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio3 = table.Column<int>(type: "int", nullable: false),
                    HoraFinal3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota1 = table.Column<double>(type: "float", nullable: false),
                    Nota2 = table.Column<double>(type: "float", nullable: false),
                    Nota3 = table.Column<double>(type: "float", nullable: false),
                    Nota4 = table.Column<double>(type: "float", nullable: false),
                    Nota5 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolPersonaId",
                table: "Personas",
                column: "RolPersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Rol_RolPersonaId",
                table: "Personas",
                column: "RolPersonaId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Rol_RolPersonaId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "GrupoEstudiantes");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Personas_RolPersonaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CodigoEstudiante",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CodigoFormador",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "CodigoTutor",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdE",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdF",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdT",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "RolPersonaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Personas");
        }
    }
}
