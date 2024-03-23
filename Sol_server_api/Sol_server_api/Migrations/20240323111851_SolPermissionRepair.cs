using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol_server_api.Migrations
{
    /// <inheritdoc />
    public partial class SolPermissionRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_folyamat_projekt_FKProcess",
                table: "folyamat");

            migrationBuilder.DropForeignKey(
                name: "FK_jogosultsag_munkatars_fo_FKPermissionName",
                table: "jogosultsag");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_projekt_ProcessStatus",
                table: "projekt");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_munkatars_fo_PLKPermission",
                table: "munkatars_fo");

            migrationBuilder.RenameColumn(
                name: "FKPermissionName",
                table: "jogosultsag",
                newName: "FKCoworkerID");

            migrationBuilder.RenameIndex(
                name: "IX_jogosultsag_FKPermissionName",
                table: "jogosultsag",
                newName: "IX_jogosultsag_FKCoworkerID");

            migrationBuilder.RenameColumn(
                name: "FKProcess",
                table: "folyamat",
                newName: "FKProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_folyamat_FKProcess",
                table: "folyamat",
                newName: "IX_folyamat_FKProjectID");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessStatus",
                table: "projekt",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PLKPermission",
                table: "munkatars_fo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "folyamat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_folyamat_projekt_FKProjectID",
                table: "folyamat",
                column: "FKProjectID",
                principalTable: "projekt",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jogosultsag_munkatars_fo_FKCoworkerID",
                table: "jogosultsag",
                column: "FKCoworkerID",
                principalTable: "munkatars_fo",
                principalColumn: "CoworkerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_folyamat_projekt_FKProjectID",
                table: "folyamat");

            migrationBuilder.DropForeignKey(
                name: "FK_jogosultsag_munkatars_fo_FKCoworkerID",
                table: "jogosultsag");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "folyamat");

            migrationBuilder.RenameColumn(
                name: "FKCoworkerID",
                table: "jogosultsag",
                newName: "FKPermissionName");

            migrationBuilder.RenameIndex(
                name: "IX_jogosultsag_FKCoworkerID",
                table: "jogosultsag",
                newName: "IX_jogosultsag_FKPermissionName");

            migrationBuilder.RenameColumn(
                name: "FKProjectID",
                table: "folyamat",
                newName: "FKProcess");

            migrationBuilder.RenameIndex(
                name: "IX_folyamat_FKProjectID",
                table: "folyamat",
                newName: "IX_folyamat_FKProcess");

            migrationBuilder.AlterColumn<string>(
                name: "ProcessStatus",
                table: "projekt",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PLKPermission",
                table: "munkatars_fo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_projekt_ProcessStatus",
                table: "projekt",
                column: "ProcessStatus");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_munkatars_fo_PLKPermission",
                table: "munkatars_fo",
                column: "PLKPermission");

            migrationBuilder.AddForeignKey(
                name: "FK_folyamat_projekt_FKProcess",
                table: "folyamat",
                column: "FKProcess",
                principalTable: "projekt",
                principalColumn: "ProcessStatus",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_jogosultsag_munkatars_fo_FKPermissionName",
                table: "jogosultsag",
                column: "FKPermissionName",
                principalTable: "munkatars_fo",
                principalColumn: "PLKPermission",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
