using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class FixPlacardInconsistencyPlusSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_placardimagebridges_images_imageid",
                table: "placardimagebridges");

            migrationBuilder.DropForeignKey(
                name: "fk_placardvideobridges_videos_videoid",
                table: "placardvideobridges");

            migrationBuilder.AddForeignKey(
                name: "fk_placardimagebridges_images_imageid",
                table: "placardimagebridges",
                column: "imageid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_placardvideobridges_videos_videoid",
                table: "placardvideobridges",
                column: "videoid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_placardimagebridges_images_imageid",
                table: "placardimagebridges");

            migrationBuilder.DropForeignKey(
                name: "fk_placardvideobridges_videos_videoid",
                table: "placardvideobridges");

            migrationBuilder.AddForeignKey(
                name: "fk_placardimagebridges_images_imageid",
                table: "placardimagebridges",
                column: "imageid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_placardvideobridges_videos_videoid",
                table: "placardvideobridges",
                column: "videoid",
                principalSchema: "viderhe_sapressc_middleware_media",
                principalTable: "videos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
