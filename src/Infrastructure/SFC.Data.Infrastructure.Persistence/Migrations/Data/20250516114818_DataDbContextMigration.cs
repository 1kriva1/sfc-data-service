using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SFC.Data.Infrastructure.Persistence.Migrations.Data
{
    /// <inheritdoc />
    public partial class DataDbContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Metadata");

            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "Domains",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootballPosition",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPosition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStyle",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStyle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shirt",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatCategory",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatSkill",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatSkill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                schema: "Metadata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingFoot",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingFoot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatType",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatType_StatCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Data",
                        principalTable: "StatCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatType_StatSkill_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Data",
                        principalTable: "StatSkill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Metadata",
                schema: "Metadata",
                columns: table => new
                {
                    Service = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Domain = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metadata", x => new { x.Service, x.Type });
                    table.ForeignKey(
                        name: "FK_Metadata_Services_Service",
                        column: x => x.Service,
                        principalSchema: "Metadata",
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Metadata_States_State",
                        column: x => x.State,
                        principalSchema: "Metadata",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Metadata_Types_Type",
                        column: x => x.Type,
                        principalSchema: "Metadata",
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Domains",
                columns: new[] { "Id", "Title" },
                values: new object[] { 0, "Data" });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "FootballPosition",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4786), "Goalkeeper" },
                    { 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4797), "Defender" },
                    { 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4807), "Midfielder" },
                    { 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4813), "Forward" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "GameStyle",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4891), "Defend" },
                    { 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4903), "Attacking" },
                    { 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4912), "Aggressive" },
                    { 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(4963), "Counter Attacks" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Services",
                columns: new[] { "Id", "Title" },
                values: new object[] { 0, "Data" });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "Shirt",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6040), "Blue" },
                    { 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6050), "Pink" },
                    { 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6085), "Black" },
                    { 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6092), "Red" },
                    { 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6098), "Yellow" },
                    { 5, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6106), "Purple" },
                    { 6, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6113), "Orange" },
                    { 7, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6119), "Brown" },
                    { 8, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(6124), "Green" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "StatCategory",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5147), "Pace" },
                    { 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5157), "Shooting" },
                    { 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5165), "Passing" },
                    { 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5172), "Dribbling" },
                    { 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5178), "Defending" },
                    { 5, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5186), "Physicality" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "StatSkill",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5263), "Physical" },
                    { 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5273), "Mental" },
                    { 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5280), "Skill" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "States",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 0, "Not Required" },
                    { 1, "Required" },
                    { 2, "Done" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Types",
                columns: new[] { "Id", "Title" },
                values: new object[] { 0, "Initialization" });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "WorkingFoot",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5049), "Right" },
                    { 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5057), "Left" },
                    { 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5063), "Both" }
                });

            migrationBuilder.InsertData(
                schema: "Metadata",
                table: "Metadata",
                columns: new[] { "Service", "Type", "Domain", "State" },
                values: new object[] { 0, 0, 0, 1 });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "StatType",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "SkillId", "Title" },
                values: new object[,]
                {
                    { 0, 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5427), 0, "Acceleration" },
                    { 1, 0, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5575), 0, "Sprint Speed" },
                    { 2, 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5587), 2, "Positioning" },
                    { 3, 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5594), 2, "Finishing" },
                    { 4, 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5614), 2, "Shot Power" },
                    { 5, 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5631), 2, "Long Shots" },
                    { 6, 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5642), 2, "Volleys" },
                    { 7, 1, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5648), 2, "Penalties" },
                    { 8, 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5656), 2, "Vision" },
                    { 9, 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5665), 2, "Crossing" },
                    { 10, 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5682), 2, "Fk Accuracy" },
                    { 11, 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5698), 2, "Short Passing" },
                    { 12, 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5740), 2, "Long Passing" },
                    { 13, 2, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5751), 2, "Curve" },
                    { 14, 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5760), 0, "Agility" },
                    { 15, 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5767), 0, "Balance" },
                    { 16, 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5775), 0, "Reactions" },
                    { 17, 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5791), 2, "Ball Control" },
                    { 18, 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5799), 2, "Dribbling" },
                    { 19, 3, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5806), 1, "Composure" },
                    { 20, 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5812), 2, "Interceptions" },
                    { 21, 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5828), 2, "Heading Accuracy" },
                    { 22, 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5844), 2, "Def Awarenence" },
                    { 23, 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5860), 2, "Standing Tackle" },
                    { 24, 4, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5875), 2, "Sliding Tackle" },
                    { 25, 5, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5883), 0, "Jumping" },
                    { 26, 5, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5890), 0, "Stamina" },
                    { 27, 5, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5896), 0, "Strength" },
                    { 28, 5, new DateTime(2025, 5, 16, 11, 48, 18, 476, DateTimeKind.Utc).AddTicks(5902), 1, "Aggression" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_State",
                schema: "Metadata",
                table: "Metadata",
                column: "State");

            migrationBuilder.CreateIndex(
                name: "IX_Metadata_Type",
                schema: "Metadata",
                table: "Metadata",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_StatType_CategoryId",
                schema: "Data",
                table: "StatType",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StatType_SkillId",
                schema: "Data",
                table: "StatType",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domains",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "FootballPosition",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "GameStyle",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Metadata",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "Shirt",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatType",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "WorkingFoot",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "States",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "Types",
                schema: "Metadata");

            migrationBuilder.DropTable(
                name: "StatCategory",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatSkill",
                schema: "Data");
        }
    }
}