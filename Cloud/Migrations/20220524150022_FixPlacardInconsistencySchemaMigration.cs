using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class FixPlacardInconsistencySchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "placardimagebridges",
                columns: table => new
                {
                    placardid = table.Column<Guid>(nullable: false),
                    imageid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_placardimagebridges", x => new { x.placardid, x.imageid });
                    table.ForeignKey(
                        name: "fk_placardimagebridges_images_imageid",
                        column: x => x.imageid,
                        principalSchema: "viderhe_sapressc_middleware_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_placardimagebridges_placards_placardid",
                        column: x => x.placardid,
                        principalTable: "placards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "placardvideobridges",
                columns: table => new
                {
                    placardid = table.Column<Guid>(nullable: false),
                    videoid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_placardvideobridges", x => new { x.placardid, x.videoid });
                    table.ForeignKey(
                        name: "fk_placardvideobridges_placards_placardid",
                        column: x => x.placardid,
                        principalTable: "placards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_placardvideobridges_videos_videoid",
                        column: x => x.videoid,
                        principalSchema: "viderhe_sapressc_middleware_media",
                        principalTable: "videos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_placardimagebridges_imageid",
                table: "placardimagebridges",
                column: "imageid");

            migrationBuilder.CreateIndex(
                name: "ix_placardvideobridges_videoid",
                table: "placardvideobridges",
                column: "videoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "placardimagebridges");

            migrationBuilder.DropTable(
                name: "placardvideobridges");
        }
    }
}
