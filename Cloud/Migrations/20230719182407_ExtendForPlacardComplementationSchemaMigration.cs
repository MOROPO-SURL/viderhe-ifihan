using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class ExtendForPlacardComplementationSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "complementationkind",
                table: "placards",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "serializedcomplementation",
                table: "placards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "complementationkind",
                table: "placards");

            migrationBuilder.DropColumn(
                name: "serializedcomplementation",
                table: "placards");
        }
    }
}
