using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cAthlet.Migrations
{
    /// <inheritdoc />
    public partial class AddBreathingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AtemEinstellungen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EinatmenSekunden = table.Column<int>(type: "int", nullable: false),
                    AnhaltenSekunden = table.Column<int>(type: "int", nullable: false),
                    AusatmenSekunden = table.Column<int>(type: "int", nullable: false),
                    PauseSekunden = table.Column<int>(type: "int", nullable: false),
                    GesamtMinuten = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtemEinstellungen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtemSitzung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbgeschlossenAm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EinatmenSekunden = table.Column<int>(type: "int", nullable: false),
                    AnhaltenSekunden = table.Column<int>(type: "int", nullable: false),
                    AusatmenSekunden = table.Column<int>(type: "int", nullable: false),
                    PauseSekunden = table.Column<int>(type: "int", nullable: false),
                    GesamtMinuten = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtemSitzung", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtemEinstellungen");

            migrationBuilder.DropTable(
                name: "AtemSitzung");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
