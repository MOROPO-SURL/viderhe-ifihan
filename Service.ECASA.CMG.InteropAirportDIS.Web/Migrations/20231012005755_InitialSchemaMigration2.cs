using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchemaMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_location_municipality_municipalityid",
                schema: "guamaframework_location",
                table: "location");

            migrationBuilder.AddForeignKey(
                name: "fk_location_municipality_municipalityid",
                schema: "guamaframework_location",
                table: "location",
                column: "municipalityid",
                principalSchema: "guamaframework_location",
                principalTable: "municipality",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_location_municipality_municipalityid",
                schema: "guamaframework_location",
                table: "location");

            migrationBuilder.AddForeignKey(
                name: "fk_location_municipality_municipalityid",
                schema: "guamaframework_location",
                table: "location",
                column: "municipalityid",
                principalSchema: "guamaframework_location",
                principalTable: "municipality",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
