using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SFC.Data.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "FootballPositions",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootballPositions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameStyles",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatCategories",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatSkills",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingFoots",
                schema: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingFoots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatTypes",
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
                    table.PrimaryKey("PK_StatTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatTypes_StatCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Data",
                        principalTable: "StatCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StatTypes_StatSkills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Data",
                        principalTable: "StatSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "FootballPositions",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1470), "Goalkeeper" },
                    { 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1472), "Defender" },
                    { 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1472), "Midfielder" },
                    { 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1473), "Forward" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "GameStyles",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1584), "Defend" },
                    { 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1585), "Attacking" },
                    { 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1585), "Aggressive" },
                    { 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1586), "Control" },
                    { 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1586), "CounterAttacks" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "StatCategories",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1635), "Pace" },
                    { 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1636), "Shooting" },
                    { 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1636), "Passing" },
                    { 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1637), "Dribbling" },
                    { 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1637), "Defending" },
                    { 5, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1637), "Physicality" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "StatSkills",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1659), "Physical" },
                    { 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1660), "Mental" },
                    { 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1660), "Skill" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "WorkingFoots",
                columns: new[] { "Id", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1610), "Right" },
                    { 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1611), "Left" },
                    { 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1611), "Both" }
                });

            migrationBuilder.InsertData(
                schema: "Data",
                table: "StatTypes",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "SkillId", "Title" },
                values: new object[,]
                {
                    { 0, 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1704), 0, "Acceleration" },
                    { 1, 0, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1705), 0, "SprintSpeed" },
                    { 2, 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1705), 2, "Positioning" },
                    { 3, 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1705), 2, "Finishing" },
                    { 4, 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1706), 2, "ShotPower" },
                    { 5, 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1706), 2, "LongShots" },
                    { 6, 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1706), 2, "Volleys" },
                    { 7, 1, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1707), 2, "Penalties" },
                    { 8, 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1707), 2, "Vision" },
                    { 9, 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1707), 2, "Crossing" },
                    { 10, 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1707), 2, "FkAccuracy" },
                    { 11, 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1708), 2, "ShortPassing" },
                    { 12, 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1708), 2, "LongPassing" },
                    { 13, 2, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1709), 2, "Curve" },
                    { 14, 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1709), 0, "Agility" },
                    { 15, 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1709), 0, "Balance" },
                    { 16, 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1709), 0, "Reactions" },
                    { 17, 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1710), 2, "BallControl" },
                    { 18, 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1710), 2, "Dribbling" },
                    { 19, 3, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1710), 1, "Composure" },
                    { 20, 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1711), 2, "Interceptions" },
                    { 21, 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1711), 2, "HeadingAccuracy" },
                    { 22, 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1711), 2, "DefAwarenence" },
                    { 23, 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1712), 2, "StandingTackle" },
                    { 24, 4, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1712), 2, "SlidingTackle" },
                    { 25, 5, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1712), 0, "Jumping" },
                    { 26, 5, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1713), 0, "Stamina" },
                    { 27, 5, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1713), 0, "Strength" },
                    { 28, 5, new DateTime(2023, 10, 27, 10, 7, 35, 876, DateTimeKind.Utc).AddTicks(1713), 1, "Aggression" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StatTypes_CategoryId",
                schema: "Data",
                table: "StatTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StatTypes_SkillId",
                schema: "Data",
                table: "StatTypes",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FootballPositions",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "GameStyles",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatTypes",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "WorkingFoots",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatCategories",
                schema: "Data");

            migrationBuilder.DropTable(
                name: "StatSkills",
                schema: "Data");
        }
    }
}
