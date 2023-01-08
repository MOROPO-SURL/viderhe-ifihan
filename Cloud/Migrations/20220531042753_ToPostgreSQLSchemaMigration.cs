using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SmartSolucionesCuba.Viderhe.Cloud.Migrations
{
    public partial class ToPostgreSQLSchemaMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationemailcontactitembridges_emailcontactitems_contac~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationemailcontactitembridges_organizationidentities_o~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationphonecontactitembridges_phonecontactitems_contac~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationphonecontactitembridges_organizationidentities_o~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationpostalcontactitembridges_postalcontactitems_cont~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationpostalcontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationsocialcontactitembridges_socialcontactitems_cont~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationsocialcontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationwebsitecontactitembridges_websitecontactitems_co~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationwebsitecontactitembridges_organizationidentities~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personemailcontactitembridges_emailcontactitems_contactitemid",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personemailcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personphonecontactitembridges_phonecontactitems_contactitemid",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personphonecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personpostalcontactitembridges_postalcontactitems_contactite~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personpostalcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personsocialcontactitembridges_socialcontactitems_contactite~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personsocialcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personwebsitecontactitembridges_websitecontactitems_contacti~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personwebsitecontactitembridges");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "viderhe_sapressc_core_securitylocal",
                table: "roles",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "traces",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "frames",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationemailcontactitembridges_emailcontactitems_conta~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "emailcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationemailcontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationphonecontactitembridges_phonecontactitems_conta~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "phonecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationphonecontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationpostalcontactitembridges_postalcontactitems_con~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationpostalcontactitembridges_organizationidentities~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationsocialcontactitembridges_socialcontactitems_con~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "socialcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationsocialcontactitembridges_organizationidentities~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationwebsitecontactitembridges_websitecontactitems_c~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "websitecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationwebsitecontactitembridges_organizationidentitie~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personemailcontactitembridges_emailcontactitems_contactitem~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personemailcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "emailcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personphonecontactitembridges_phonecontactitems_contactitem~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personphonecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "phonecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personpostalcontactitembridges_postalcontactitems_contactit~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personpostalcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personsocialcontactitembridges_socialcontactitems_contactit~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personsocialcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "socialcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personwebsitecontactitembridges_websitecontactitems_contact~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personwebsitecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "websitecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationemailcontactitembridges_emailcontactitems_conta~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationemailcontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationphonecontactitembridges_phonecontactitems_conta~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationphonecontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationpostalcontactitembridges_postalcontactitems_con~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationpostalcontactitembridges_organizationidentities~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationsocialcontactitembridges_socialcontactitems_con~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationsocialcontactitembridges_organizationidentities~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationwebsitecontactitembridges_websitecontactitems_c~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationwebsitecontactitembridges_organizationidentitie~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personemailcontactitembridges_emailcontactitems_contactitem~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personemailcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personphonecontactitembridges_phonecontactitems_contactitem~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personphonecontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personpostalcontactitembridges_postalcontactitems_contactit~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personpostalcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personsocialcontactitembridges_socialcontactitems_contactit~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personsocialcontactitembridges");

            migrationBuilder.DropForeignKey(
                name: "fk_personwebsitecontactitembridges_websitecontactitems_contact~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personwebsitecontactitembridges");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "viderhe_sapressc_core_securitylocal",
                table: "roles",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "traces",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<long>(
                name: "id",
                table: "frames",
                nullable: false,
                oldClrType: typeof(long))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationemailcontactitembridges_emailcontactitems_contac~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "emailcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationemailcontactitembridges_organizationidentities_o~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationemailcontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationphonecontactitembridges_phonecontactitems_contac~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "phonecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationphonecontactitembridges_organizationidentities_o~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationphonecontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationpostalcontactitembridges_postalcontactitems_cont~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationpostalcontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationpostalcontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationsocialcontactitembridges_socialcontactitems_cont~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "socialcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationsocialcontactitembridges_organizationidentities_~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationsocialcontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationwebsitecontactitembridges_websitecontactitems_co~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "websitecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationwebsitecontactitembridges_organizationidentities~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "organizationwebsitecontactitembridges",
                column: "organizationid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personemailcontactitembridges_emailcontactitems_contactitemid",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personemailcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "emailcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personphonecontactitembridges_phonecontactitems_contactitemid",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personphonecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "phonecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personpostalcontactitembridges_postalcontactitems_contactite~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personpostalcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personsocialcontactitembridges_socialcontactitems_contactite~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personsocialcontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "socialcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personwebsitecontactitembridges_websitecontactitems_contacti~",
                schema: "viderhe_sapressc_middleware_identity",
                table: "personwebsitecontactitembridges",
                column: "contactitemid",
                principalSchema: "viderhe_sapressc_middleware_identity",
                principalTable: "websitecontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
