using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol_server_api.Migrations
{
    /// <inheritdoc />
    public partial class SolAfterAPIC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alkatresz_projekt_csomag_FKPackageID",
                table: "alkatresz");

            migrationBuilder.DropForeignKey(
                name: "FK_rekesz_alkatresz_FKComponentID",
                table: "rekesz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jogosultsag",
                table: "jogosultsag");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionID",
                table: "jogosultsag",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PermissionName",
                table: "jogosultsag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jogosultsag",
                table: "jogosultsag",
                column: "PermissionID");

            migrationBuilder.AddForeignKey(
                name: "FK_alkatresz_projekt_csomag_FKPackageID",
                table: "alkatresz",
                column: "FKPackageID",
                principalTable: "projekt_csomag",
                principalColumn: "PackageID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_rekesz_alkatresz_FKComponentID",
                table: "rekesz",
                column: "FKComponentID",
                principalTable: "alkatresz",
                principalColumn: "ComponentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_alkatresz_projekt_csomag_FKPackageID",
                table: "alkatresz");

            migrationBuilder.DropForeignKey(
                name: "FK_rekesz_alkatresz_FKComponentID",
                table: "rekesz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jogosultsag",
                table: "jogosultsag");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionName",
                table: "jogosultsag",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PermissionID",
                table: "jogosultsag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_jogosultsag",
                table: "jogosultsag",
                column: "PermissionName");

            migrationBuilder.AddForeignKey(
                name: "FK_alkatresz_projekt_csomag_FKPackageID",
                table: "alkatresz",
                column: "FKPackageID",
                principalTable: "projekt_csomag",
                principalColumn: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK_rekesz_alkatresz_FKComponentID",
                table: "rekesz",
                column: "FKComponentID",
                principalTable: "alkatresz",
                principalColumn: "ComponentID");
        }
    }
}
