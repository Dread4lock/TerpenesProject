using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerpenesProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConditionId",
                table: "Terpenes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConditionCondition",
                columns: table => new
                {
                    AllConditionsId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FilteredConditionsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionCondition", x => new { x.AllConditionsId, x.FilteredConditionsId });
                    table.ForeignKey(
                        name: "FK_ConditionCondition_Conditions_AllConditionsId",
                        column: x => x.AllConditionsId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConditionCondition_Conditions_FilteredConditionsId",
                        column: x => x.FilteredConditionsId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerpeneTerpene",
                columns: table => new
                {
                    AllTerpenesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FilteredTerpenesId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerpeneTerpene", x => new { x.AllTerpenesId, x.FilteredTerpenesId });
                    table.ForeignKey(
                        name: "FK_TerpeneTerpene_Terpenes_AllTerpenesId",
                        column: x => x.AllTerpenesId,
                        principalTable: "Terpenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerpeneTerpene_Terpenes_FilteredTerpenesId",
                        column: x => x.FilteredTerpenesId,
                        principalTable: "Terpenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Terpenes_ConditionId",
                table: "Terpenes",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionCondition_FilteredConditionsId",
                table: "ConditionCondition",
                column: "FilteredConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TerpeneTerpene_FilteredTerpenesId",
                table: "TerpeneTerpene",
                column: "FilteredTerpenesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Terpenes_Conditions_ConditionId",
                table: "Terpenes",
                column: "ConditionId",
                principalTable: "Conditions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Terpenes_Conditions_ConditionId",
                table: "Terpenes");

            migrationBuilder.DropTable(
                name: "ConditionCondition");

            migrationBuilder.DropTable(
                name: "TerpeneTerpene");

            migrationBuilder.DropIndex(
                name: "IX_Terpenes_ConditionId",
                table: "Terpenes");

            migrationBuilder.DropColumn(
                name: "ConditionId",
                table: "Terpenes");
        }
    }
}
