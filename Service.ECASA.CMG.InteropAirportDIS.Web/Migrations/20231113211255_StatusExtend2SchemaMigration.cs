using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Migrations
{
    /// <inheritdoc />
    public partial class StatusExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "defaultcolor",
                table: "statuses");

            migrationBuilder.RenameColumn(
                name: "variationcolor",
                table: "statuses",
                newName: "emphasistextcolor");

            migrationBuilder.AddColumn<string>(
                name: "alternatebackgroundcolor",
                table: "statuses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "alternatetextcolor",
                table: "statuses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emphasisbackgroundcolor",
                table: "statuses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alternatebackgroundcolor",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "alternatetextcolor",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "emphasisbackgroundcolor",
                table: "statuses");

            migrationBuilder.RenameColumn(
                name: "emphasistextcolor",
                table: "statuses",
                newName: "variationcolor");

            migrationBuilder.AddColumn<string>(
                name: "defaultcolor",
                table: "statuses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
