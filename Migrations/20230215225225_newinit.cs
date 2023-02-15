using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivitatiVoluntariatWEB.Migrations
{
    public partial class newinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departament",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeDepartament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordonator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumarVoluntari = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Responsabil",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeResponsabil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Functie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsabil", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voluntar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voluntar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Voluntar_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Activitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeActivitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsabilID = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Punctaj = table.Column<int>(type: "int", nullable: false),
                    DepartamentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activitate_Departament_DepartamentID",
                        column: x => x.DepartamentID,
                        principalTable: "Departament",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Activitate_Responsabil_ResponsabilID",
                        column: x => x.ResponsabilID,
                        principalTable: "Responsabil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Inscriere",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoluntarID = table.Column<int>(type: "int", nullable: true),
                    ActivitateID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriere", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Inscriere_Activitate_ActivitateID",
                        column: x => x.ActivitateID,
                        principalTable: "Activitate",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Inscriere_Voluntar_VoluntarID",
                        column: x => x.VoluntarID,
                        principalTable: "Voluntar",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activitate_DepartamentID",
                table: "Activitate",
                column: "DepartamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Activitate_ResponsabilID",
                table: "Activitate",
                column: "ResponsabilID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_ActivitateID",
                table: "Inscriere",
                column: "ActivitateID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscriere_VoluntarID",
                table: "Inscriere",
                column: "VoluntarID");

            migrationBuilder.CreateIndex(
                name: "IX_Voluntar_DepartamentID",
                table: "Voluntar",
                column: "DepartamentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscriere");

            migrationBuilder.DropTable(
                name: "Activitate");

            migrationBuilder.DropTable(
                name: "Voluntar");

            migrationBuilder.DropTable(
                name: "Responsabil");

            migrationBuilder.DropTable(
                name: "Departament");
        }
    }
}
