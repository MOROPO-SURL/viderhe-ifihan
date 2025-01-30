using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class FIDSChangesSyncronizationSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_checkins_operations_arrivaloperationid",
                table: "checkins");

            migrationBuilder.AlterColumn<long>(
                name: "arrivaloperationid",
                table: "checkins",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "fk_checkins_operations_arrivaloperationid",
                table: "checkins",
                column: "arrivaloperationid",
                principalTable: "operations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_checkins_operations_arrivaloperationid",
                table: "checkins");

            migrationBuilder.AlterColumn<long>(
                name: "arrivaloperationid",
                table: "checkins",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_checkins_operations_arrivaloperationid",
                table: "checkins",
                column: "arrivaloperationid",
                principalTable: "operations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
