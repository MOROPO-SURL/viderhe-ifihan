using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class AccountInformationExtendSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_images_splashid",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "splashid",
                table: "accounts",
                newName: "verticalsplashid");

            migrationBuilder.RenameIndex(
                name: "ix_accounts_splashid",
                table: "accounts",
                newName: "ix_accounts_verticalsplashid");

            migrationBuilder.AddColumn<Guid>(
                name: "horizontalsplashid",
                table: "accounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_accounts_horizontalsplashid",
                table: "accounts",
                column: "horizontalsplashid");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_images_horizontalsplashid",
                table: "accounts",
                column: "horizontalsplashid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_images_verticalsplashid",
                table: "accounts",
                column: "verticalsplashid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_images_horizontalsplashid",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "fk_accounts_images_verticalsplashid",
                table: "accounts");

            migrationBuilder.DropIndex(
                name: "ix_accounts_horizontalsplashid",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "horizontalsplashid",
                table: "accounts");

            migrationBuilder.RenameColumn(
                name: "verticalsplashid",
                table: "accounts",
                newName: "splashid");

            migrationBuilder.RenameIndex(
                name: "ix_accounts_verticalsplashid",
                table: "accounts",
                newName: "ix_accounts_splashid");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_images_splashid",
                table: "accounts",
                column: "splashid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
