using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Class = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Race = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Backstory = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCharacterList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    GroupEntityGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCharacterList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerCharacterList_Groups_GroupEntityGroupId",
                        column: x => x.GroupEntityGroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feats",
                columns: table => new
                {
                    FeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatPrerequisites = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatBenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatNormal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatSpecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeatCombatFeat = table.Column<bool>(type: "bit", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feats", x => x.FeatId);
                    table.ForeignKey(
                        name: "FK_Feats_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_GroupId",
                table: "Characters",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Feats_CharacterId",
                table: "Feats",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCharacterList_GroupEntityGroupId",
                table: "PlayerCharacterList",
                column: "GroupEntityGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feats");

            migrationBuilder.DropTable(
                name: "PlayerCharacterList");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
