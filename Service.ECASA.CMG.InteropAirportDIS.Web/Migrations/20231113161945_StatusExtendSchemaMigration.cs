using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Migrations
{
    /// <inheritdoc />
    public partial class StatusExtendSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "stardate",
                table: "operations",
                newName: "startdate");

            migrationBuilder.AddColumn<string>(
                name: "defaultcolor",
                table: "statuses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "variationcolor",
                table: "statuses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "defaultcolor",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "variationcolor",
                table: "statuses");

            migrationBuilder.RenameColumn(
                name: "startdate",
                table: "operations",
                newName: "stardate");
        }
    }
}
