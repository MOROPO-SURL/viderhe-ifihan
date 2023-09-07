using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixAVProductionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_avproductions_videos_videoid",
                table: "avproductions");

            migrationBuilder.AlterColumn<int>(
                name: "videoquality",
                table: "avproductions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "videoid",
                table: "avproductions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<long>(
                name: "filesize",
                table: "avproductions",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "fk_avproductions_videos_videoid",
                table: "avproductions",
                column: "videoid",
                principalSchema: "guamaframework_media",
                principalTable: "videos",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_avproductions_videos_videoid",
                table: "avproductions");

            migrationBuilder.AlterColumn<int>(
                name: "videoquality",
                table: "avproductions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "videoid",
                table: "avproductions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "filesize",
                table: "avproductions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_avproductions_videos_videoid",
                table: "avproductions",
                column: "videoid",
                principalSchema: "guamaframework_media",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
