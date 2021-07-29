using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class MinorExtendPlacardSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "playerorientationsupportkind",
                table: "placards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "playerorientationsupportkind",
                table: "placards");
        }
    }
}
