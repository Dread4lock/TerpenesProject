using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerpenesProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aromas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aromas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerpeneAromas",
                columns: table => new
                {
                    AromasId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TerpenesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerpeneAromas", x => new { x.AromasId, x.TerpenesId });
                    table.ForeignKey(
                        name: "FK_TerpeneAromas_Aromas_AromasId",
                        column: x => x.AromasId,
                        principalTable: "Aromas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerpeneAromas_Terpenes_TerpenesId",
                        column: x => x.TerpenesId,
                        principalTable: "Terpenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerpeneAromas_TerpenesId",
                table: "TerpeneAromas",
                column: "TerpenesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerpeneAromas");

            migrationBuilder.DropTable(
                name: "Aromas");
        }
    }
}
