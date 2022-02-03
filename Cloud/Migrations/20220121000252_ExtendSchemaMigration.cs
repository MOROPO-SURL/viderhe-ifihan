using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class ExtendSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scheduledrelaunches",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    playerid = table.Column<string>(nullable: false),
                    time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_scheduledrelaunches", x => x.id);
                    table.ForeignKey(
                        name: "fk_scheduledrelaunches_players_playerid",
                        column: x => x.playerid,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_scheduledrelaunches_playerid",
                table: "scheduledrelaunches",
                column: "playerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scheduledrelaunches");
        }
    }
}
