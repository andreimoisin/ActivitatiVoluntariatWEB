using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivitatiVoluntariatWEB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Activitate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeActivitate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsabilID = table.Column<int>(type: "int", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Punctaj = table.Column<int>(type: "int", nullable: false),
                    Departament = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activitate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Activitate_Responsabil_ResponsabilID",
                        column: x => x.ResponsabilID,
                        principalTable: "Responsabil",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activitate_ResponsabilID",
                table: "Activitate",
                column: "ResponsabilID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activitate");

            migrationBuilder.DropTable(
                name: "Responsabil");
        }
    }
}
