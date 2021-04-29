using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class FixPlacardTemplateForeignKyNameSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_placards_templates_tempateid",
                table: "placards");

            migrationBuilder.DropIndex(
                name: "ix_placards_tempateid",
                table: "placards");

            migrationBuilder.DropColumn(
                name: "tempateid",
                table: "placards");

            migrationBuilder.CreateIndex(
                name: "ix_placards_templateid",
                table: "placards",
                column: "templateid");

            migrationBuilder.AddForeignKey(
                name: "fk_placards_templates_templateid",
                table: "placards",
                column: "templateid",
                principalTable: "templates",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_placards_templates_templateid",
                table: "placards");

            migrationBuilder.DropIndex(
                name: "ix_placards_templateid",
                table: "placards");

            migrationBuilder.AddColumn<Guid>(
                name: "tempateid",
                table: "placards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_placards_tempateid",
                table: "placards",
                column: "tempateid");

            migrationBuilder.AddForeignKey(
                name: "fk_placards_templates_tempateid",
                table: "placards",
                column: "tempateid",
                principalTable: "templates",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
