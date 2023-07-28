using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class IncludeTagAndPartialBridgesSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    group = table.Column<int>(nullable: false),
                    color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "placardtagbridges",
                columns: table => new
                {
                    placardid = table.Column<Guid>(nullable: false),
                    tagid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_placardtagbridges", x => new { x.placardid, x.tagid });
                    table.ForeignKey(
                        name: "fk_placardtagbridges_placards_placardid",
                        column: x => x.placardid,
                        principalTable: "placards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_placardtagbridges_tags_tagid",
                        column: x => x.tagid,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playertagbridges",
                columns: table => new
                {
                    playerid = table.Column<string>(nullable: false),
                    tagid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_playertagbridges", x => new { x.playerid, x.tagid });
                    table.ForeignKey(
                        name: "fk_playertagbridges_players_playerid",
                        column: x => x.playerid,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_playertagbridges_tags_tagid",
                        column: x => x.tagid,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_placardtagbridges_tagid",
                table: "placardtagbridges",
                column: "tagid");

            migrationBuilder.CreateIndex(
                name: "ix_playertagbridges_tagid",
                table: "playertagbridges",
                column: "tagid");

            migrationBuilder.CreateIndex(
                name: "ix_tags_group_name",
                table: "tags",
                columns: new[] { "group", "name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "placardtagbridges");

            migrationBuilder.DropTable(
                name: "playertagbridges");

            migrationBuilder.DropTable(
                name: "tags");
        }
    }
}
