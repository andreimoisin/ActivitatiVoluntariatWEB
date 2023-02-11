using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivitatiVoluntariatWEB.Migrations
{
    public partial class DepartamenteCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departament",
                table: "Activitate");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentID",
                table: "Activitate",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Activitate_DepartamentID",
                table: "Activitate",
                column: "DepartamentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Activitate_Departament_DepartamentID",
                table: "Activitate",
                column: "DepartamentID",
                principalTable: "Departament",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activitate_Departament_DepartamentID",
                table: "Activitate");

            migrationBuilder.DropTable(
                name: "Departament");

            migrationBuilder.DropIndex(
                name: "IX_Activitate_DepartamentID",
                table: "Activitate");

            migrationBuilder.DropColumn(
                name: "DepartamentID",
                table: "Activitate");

            migrationBuilder.AddColumn<string>(
                name: "Departament",
                table: "Activitate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
