using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class CompleteTagSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_tags_group_name",
                table: "tags");

            migrationBuilder.AddColumn<Guid>(
                name: "accountid",
                table: "tags",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_tags_accountid",
                table: "tags",
                column: "accountid");

            migrationBuilder.CreateIndex(
                name: "ix_tags_group_name_accountid",
                table: "tags",
                columns: new[] { "group", "name", "accountid" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_tags_accounts_accountid",
                table: "tags",
                column: "accountid",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tags_accounts_accountid",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_accountid",
                table: "tags");

            migrationBuilder.DropIndex(
                name: "ix_tags_group_name_accountid",
                table: "tags");

            migrationBuilder.DropColumn(
                name: "accountid",
                table: "tags");

            migrationBuilder.CreateIndex(
                name: "ix_tags_group_name",
                table: "tags",
                columns: new[] { "group", "name" },
                unique: true);
        }
    }
}
