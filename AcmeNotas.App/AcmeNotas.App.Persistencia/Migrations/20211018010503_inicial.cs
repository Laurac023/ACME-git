using Microsoft.EntityFrameworkCore.Migrations;

namespace AcmeNotas.App.Persistencia.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoHorario = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CodDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioPersonaId = table.Column<int>(type: "int", nullable: true),
                    RolPersonaId = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerRegistro = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoAdm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupoId = table.Column<int>(type: "int", nullable: true),
                    CodigoEstudiante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoFormador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoTutor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Municipios_MunicipioPersonaId",
                        column: x => x.MunicipioPersonaId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Roles_RolPersonaId",
                        column: x => x.RolPersonaId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormadorId = table.Column<int>(type: "int", nullable: true),
                    TutorId = table.Column<int>(type: "int", nullable: true),
                    CodigoGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciclo = table.Column<int>(type: "int", nullable: false),
                    HorarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoId);
                    table.ForeignKey(
                        name: "FK_Grupos_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_Personas_FormadorId",
                        column: x => x.FormadorId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_Personas_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estudianteId = table.Column<int>(type: "int", nullable: true),
                    Nota1 = table.Column<double>(type: "float", nullable: false),
                    Nota2 = table.Column<double>(type: "float", nullable: false),
                    Nota3 = table.Column<double>(type: "float", nullable: false),
                    Nota4 = table.Column<double>(type: "float", nullable: false),
                    Nota5 = table.Column<double>(type: "float", nullable: false),
                    NotaDefinitiva = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Personas_estudianteId",
                        column: x => x.estudianteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_FormadorId",
                table: "Grupos",
                column: "FormadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_HorarioId",
                table: "Grupos",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_TutorId",
                table: "Grupos",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_estudianteId",
                table: "Notas",
                column: "estudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_GrupoId",
                table: "Personas",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_MunicipioPersonaId",
                table: "Personas",
                column: "MunicipioPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_RolPersonaId",
                table: "Personas",
                column: "RolPersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Grupos_GrupoId",
                table: "Personas",
                column: "GrupoId",
                principalTable: "Grupos",
                principalColumn: "GrupoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Horarios_HorarioId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Personas_FormadorId",
                table: "Grupos");

            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_Personas_TutorId",
                table: "Grupos");

            migrationBuilder.DropTable(
                name: "GrupoEstudiantes");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
