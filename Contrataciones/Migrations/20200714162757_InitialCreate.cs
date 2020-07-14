using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Contrataciones.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trabajador",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIdentificacion = table.Column<string>(nullable: true),
                    NumIdentificacion = table.Column<int>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    edad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajador", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    ContratoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEntidad = table.Column<string>(nullable: true),
                    NumeroContrato = table.Column<int>(nullable: false),
                    TrabajadorID = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.ContratoID);
                    table.ForeignKey(
                        name: "FK_Contrato_Trabajador_TrabajadorID",
                        column: x => x.TrabajadorID,
                        principalTable: "Trabajador",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TrabajadorID",
                table: "Contrato",
                column: "TrabajadorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Trabajador");
        }
    }
}
