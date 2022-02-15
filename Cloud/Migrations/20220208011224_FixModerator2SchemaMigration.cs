using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class FixModerator2SchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isprivileged",
                table: "moderators");

            migrationBuilder.AddColumn<int>(
                name: "moderationkind",
                table: "moderators",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "moderationkind",
                table: "moderators");

            migrationBuilder.AddColumn<bool>(
                name: "isprivileged",
                table: "moderators",
                nullable: false,
                defaultValue: false);
        }
    }
}
