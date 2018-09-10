using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace payback4marvin.Migrations
{
    public partial class DbErstellt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerbrecherDb",
                columns: table => new
                {
                    VerbrecherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vorname = table.Column<string>(nullable: true),
                    Nachname = table.Column<string>(nullable: true),
                    Geburtstag = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbrecherDb", x => x.VerbrecherId);
                });

            migrationBuilder.CreateTable(
                name: "VergehenDb",
                columns: table => new
                {
                    VergehenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bezeichnung = table.Column<string>(nullable: true),
                    VerbrecherId = table.Column<int>(nullable: false),
                    TatZeitpunkt = table.Column<DateTimeOffset>(nullable: false),
                    Stärke = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VergehenDb", x => x.VergehenId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerbrecherDb");

            migrationBuilder.DropTable(
                name: "VergehenDb");
        }
    }
}
