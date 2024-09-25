using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TerpenesProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aromas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aromas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionCondition",
                columns: table => new
                {
                    AllConditionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilteredConditionsId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Terpenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Aroma = table.Column<string>(type: "TEXT", nullable: false),
                    ConditionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terpenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terpenes_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TerpeneAromas",
                columns: table => new
                {
                    AromasId = table.Column<int>(type: "INTEGER", nullable: false),
                    TerpenesId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TerpenesConditions",
                columns: table => new
                {
                    TerpeneId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConditionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerpenesConditions", x => new { x.TerpeneId, x.ConditionId });
                    table.ForeignKey(
                        name: "FK_TerpenesConditions_Conditions_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerpenesConditions_Terpenes_TerpeneId",
                        column: x => x.TerpeneId,
                        principalTable: "Terpenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TerpeneTerpene",
                columns: table => new
                {
                    AllTerpenesId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilteredTerpenesId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "IX_ConditionCondition_FilteredConditionsId",
                table: "ConditionCondition",
                column: "FilteredConditionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TerpeneAromas_TerpenesId",
                table: "TerpeneAromas",
                column: "TerpenesId");

            migrationBuilder.CreateIndex(
                name: "IX_Terpenes_ConditionId",
                table: "Terpenes",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TerpenesConditions_ConditionId",
                table: "TerpenesConditions",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_TerpeneTerpene_FilteredTerpenesId",
                table: "TerpeneTerpene",
                column: "FilteredTerpenesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionCondition");

            migrationBuilder.DropTable(
                name: "TerpeneAromas");

            migrationBuilder.DropTable(
                name: "TerpenesConditions");

            migrationBuilder.DropTable(
                name: "TerpeneTerpene");

            migrationBuilder.DropTable(
                name: "Aromas");

            migrationBuilder.DropTable(
                name: "Terpenes");

            migrationBuilder.DropTable(
                name: "Conditions");
        }
    }
}
