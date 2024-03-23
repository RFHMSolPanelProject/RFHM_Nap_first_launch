using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol_server_api.Migrations
{
    /// <inheritdoc />
    public partial class SolConstraintRepair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoworkerProject_projekt_ProjectsProjectID",
                table: "CoworkerProject");

            migrationBuilder.DropColumn(
                name: "CoworkerID",
                table: "szemelyi_adat");

            migrationBuilder.RenameColumn(
                name: "ProjectsProjectID",
                table: "CoworkerProject",
                newName: "ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_CoworkerProject_ProjectsProjectID",
                table: "CoworkerProject",
                newName: "IX_CoworkerProject_ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_CoworkerProject_projekt_ProjectID",
                table: "CoworkerProject",
                column: "ProjectID",
                principalTable: "projekt",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoworkerProject_projekt_ProjectID",
                table: "CoworkerProject");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "CoworkerProject",
                newName: "ProjectsProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_CoworkerProject_ProjectID",
                table: "CoworkerProject",
                newName: "IX_CoworkerProject_ProjectsProjectID");

            migrationBuilder.AddColumn<string>(
                name: "CoworkerID",
                table: "szemelyi_adat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CoworkerProject_projekt_ProjectsProjectID",
                table: "CoworkerProject",
                column: "ProjectsProjectID",
                principalTable: "projekt",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
