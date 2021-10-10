using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class FixMinorModeratorSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accountmoderatorbridges_moderators_moderatorid1",
                table: "accountmoderatorbridges");

            migrationBuilder.DropIndex(
                name: "ix_accountmoderatorbridges_moderatorid1",
                table: "accountmoderatorbridges");

            migrationBuilder.DropColumn(
                name: "moderatorid1",
                table: "accountmoderatorbridges");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "moderatorid1",
                table: "accountmoderatorbridges",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_accountmoderatorbridges_moderatorid1",
                table: "accountmoderatorbridges",
                column: "moderatorid1");

            migrationBuilder.AddForeignKey(
                name: "fk_accountmoderatorbridges_moderators_moderatorid1",
                table: "accountmoderatorbridges",
                column: "moderatorid1",
                principalTable: "moderators",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
