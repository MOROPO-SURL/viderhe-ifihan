using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendCheckInSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_checkins_operations_operationid",
                table: "checkins");

            migrationBuilder.RenameColumn(
                name: "operationid",
                table: "checkins",
                newName: "departureoperationid");

            migrationBuilder.RenameIndex(
                name: "ix_checkins_operationid",
                table: "checkins",
                newName: "ix_checkins_departureoperationid");

            migrationBuilder.AddColumn<long>(
                name: "arrivaloperationid",
                table: "checkins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "ix_checkins_arrivaloperationid",
                table: "checkins",
                column: "arrivaloperationid");

            migrationBuilder.AddForeignKey(
                name: "fk_checkins_operations_arrivaloperationid",
                table: "checkins",
                column: "arrivaloperationid",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_checkins_operations_departureoperationid",
                table: "checkins",
                column: "departureoperationid",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_checkins_operations_arrivaloperationid",
                table: "checkins");

            migrationBuilder.DropForeignKey(
                name: "fk_checkins_operations_departureoperationid",
                table: "checkins");

            migrationBuilder.DropIndex(
                name: "ix_checkins_arrivaloperationid",
                table: "checkins");

            migrationBuilder.DropColumn(
                name: "arrivaloperationid",
                table: "checkins");

            migrationBuilder.RenameColumn(
                name: "departureoperationid",
                table: "checkins",
                newName: "operationid");

            migrationBuilder.RenameIndex(
                name: "ix_checkins_departureoperationid",
                table: "checkins",
                newName: "ix_checkins_operationid");

            migrationBuilder.AddForeignKey(
                name: "fk_checkins_operations_operationid",
                table: "checkins",
                column: "operationid",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
