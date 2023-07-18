using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class ExtendCentralizedContentManagementSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gradients",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createat = table.Column<DateTime>(nullable: false),
                    data = table.Column<string>(nullable: false),
                    about = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gradients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sounds",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createat = table.Column<DateTime>(nullable: false),
                    extension = table.Column<string>(nullable: false),
                    length = table.Column<long>(nullable: false),
                    about = table.Column<string>(maxLength: 255, nullable: true),
                    duration = table.Column<TimeSpan>(nullable: false),
                    audioformat = table.Column<string>(nullable: true),
                    audiochanneloutput = table.Column<string>(nullable: true),
                    thumbnailid = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sounds", x => x.id);
                    table.ForeignKey(
                        name: "fk_sounds_thumbnails_thumbnailid",
                        column: x => x.thumbnailid,
                        principalSchema: "viderhe_sapressc_middleware_media",
                        principalTable: "thumbnails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "text",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    createat = table.Column<DateTime>(nullable: false),
                    content = table.Column<string>(nullable: false),
                    about = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_text", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "accountgradientbridges",
                columns: table => new
                {
                    accountid = table.Column<Guid>(nullable: false),
                    gradientid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accountgradientbridges", x => new { x.accountid, x.gradientid });
                    table.ForeignKey(
                        name: "fk_accountgradientbridges_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accountgradientbridges_gradients_gradientid",
                        column: x => x.gradientid,
                        principalTable: "gradients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "placardgradientbridges",
                columns: table => new
                {
                    placardid = table.Column<Guid>(nullable: false),
                    gradientid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_placardgradientbridges", x => new { x.placardid, x.gradientid });
                    table.ForeignKey(
                        name: "fk_placardgradientbridges_gradients_gradientid",
                        column: x => x.gradientid,
                        principalTable: "gradients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_placardgradientbridges_placards_placardid",
                        column: x => x.placardid,
                        principalTable: "placards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "accountsoundbridges",
                columns: table => new
                {
                    accountid = table.Column<Guid>(nullable: false),
                    soundid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accountsoundbridges", x => new { x.accountid, x.soundid });
                    table.ForeignKey(
                        name: "fk_accountsoundbridges_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accountsoundbridges_sounds_soundid",
                        column: x => x.soundid,
                        principalTable: "sounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "placardsoundbridges",
                columns: table => new
                {
                    placardid = table.Column<Guid>(nullable: false),
                    soundid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_placardsoundbridges", x => new { x.placardid, x.soundid });
                    table.ForeignKey(
                        name: "fk_placardsoundbridges_placards_placardid",
                        column: x => x.placardid,
                        principalTable: "placards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_placardsoundbridges_sounds_soundid",
                        column: x => x.soundid,
                        principalTable: "sounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounttextbridges",
                columns: table => new
                {
                    accountid = table.Column<Guid>(nullable: false),
                    textid = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounttextbridges", x => new { x.accountid, x.textid });
                    table.ForeignKey(
                        name: "fk_accounttextbridges_accounts_accountid",
                        column: x => x.accountid,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_accounttextbridges_text_textid",
                        column: x => x.textid,
                        principalTable: "text",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_accountgradientbridges_gradientid",
                table: "accountgradientbridges",
                column: "gradientid");

            migrationBuilder.CreateIndex(
                name: "ix_accountsoundbridges_soundid",
                table: "accountsoundbridges",
                column: "soundid");

            migrationBuilder.CreateIndex(
                name: "ix_accounttextbridges_textid",
                table: "accounttextbridges",
                column: "textid");

            migrationBuilder.CreateIndex(
                name: "ix_placardgradientbridges_gradientid",
                table: "placardgradientbridges",
                column: "gradientid");

            migrationBuilder.CreateIndex(
                name: "ix_placardsoundbridges_soundid",
                table: "placardsoundbridges",
                column: "soundid");

            migrationBuilder.CreateIndex(
                name: "ix_sounds_thumbnailid",
                table: "sounds",
                column: "thumbnailid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accountgradientbridges");

            migrationBuilder.DropTable(
                name: "accountsoundbridges");

            migrationBuilder.DropTable(
                name: "accounttextbridges");

            migrationBuilder.DropTable(
                name: "placardgradientbridges");

            migrationBuilder.DropTable(
                name: "placardsoundbridges");

            migrationBuilder.DropTable(
                name: "text");

            migrationBuilder.DropTable(
                name: "gradients");

            migrationBuilder.DropTable(
                name: "sounds");
        }
    }
}
