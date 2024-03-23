using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol_server_api.Migrations
{
    /// <inheritdoc />
    public partial class SolInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "megrendelo",
                columns: table => new
                {
                    CustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_megrendelo", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "munkatars_fo",
                columns: table => new
                {
                    CoworkerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoworkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PLKPermission = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PLKTelNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PLKLoginID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_munkatars_fo", x => x.CoworkerID);
                    table.UniqueConstraint("AK_munkatars_fo_PLKLoginID", x => x.PLKLoginID);
                    table.UniqueConstraint("AK_munkatars_fo_PLKPermission", x => x.PLKPermission);
                    table.UniqueConstraint("AK_munkatars_fo_PLKTelNumber", x => x.PLKTelNumber);
                });

            migrationBuilder.CreateTable(
                name: "projekt",
                columns: table => new
                {
                    ProjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessStatus = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FKCustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekt", x => x.ProjectID);
                    table.UniqueConstraint("AK_projekt_ProcessStatus", x => x.ProcessStatus);
                    table.ForeignKey(
                        name: "FK_projekt_megrendelo_FKCustomerID",
                        column: x => x.FKCustomerID,
                        principalTable: "megrendelo",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jogosultsag",
                columns: table => new
                {
                    PermissionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermissionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKPermissionName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogosultsag", x => x.PermissionName);
                    table.ForeignKey(
                        name: "FK_jogosultsag_munkatars_fo_FKPermissionName",
                        column: x => x.FKPermissionName,
                        principalTable: "munkatars_fo",
                        principalColumn: "PLKPermission",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    LoginID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_login", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_login_munkatars_fo_LoginID",
                        column: x => x.LoginID,
                        principalTable: "munkatars_fo",
                        principalColumn: "PLKLoginID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "szemelyi_adat",
                columns: table => new
                {
                    TelNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoworkerID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_szemelyi_adat", x => x.TelNumber);
                    table.ForeignKey(
                        name: "FK_szemelyi_adat_munkatars_fo_TelNumber",
                        column: x => x.TelNumber,
                        principalTable: "munkatars_fo",
                        principalColumn: "PLKTelNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoworkerProject",
                columns: table => new
                {
                    CoworkersCoworkerID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsProjectID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoworkerProject", x => new { x.CoworkersCoworkerID, x.ProjectsProjectID });
                    table.ForeignKey(
                        name: "FK_CoworkerProject_munkatars_fo_CoworkersCoworkerID",
                        column: x => x.CoworkersCoworkerID,
                        principalTable: "munkatars_fo",
                        principalColumn: "CoworkerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoworkerProject_projekt_ProjectsProjectID",
                        column: x => x.ProjectsProjectID,
                        principalTable: "projekt",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "folyamat",
                columns: table => new
                {
                    ProcessID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FKProcess = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folyamat", x => x.ProcessID);
                    table.ForeignKey(
                        name: "FK_folyamat_projekt_FKProcess",
                        column: x => x.FKProcess,
                        principalTable: "projekt",
                        principalColumn: "ProcessStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projekt_csomag",
                columns: table => new
                {
                    PackageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RequiredComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredPiece = table.Column<int>(type: "int", nullable: false),
                    FKProjectID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekt_csomag", x => x.PackageID);
                    table.ForeignKey(
                        name: "FK_projekt_csomag_projekt_FKProjectID",
                        column: x => x.FKProjectID,
                        principalTable: "projekt",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alkatresz",
                columns: table => new
                {
                    ComponentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    StockStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompartmentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FKPackageID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alkatresz", x => x.ComponentID);
                    table.ForeignKey(
                        name: "FK_alkatresz_projekt_csomag_FKPackageID",
                        column: x => x.FKPackageID,
                        principalTable: "projekt_csomag",
                        principalColumn: "PackageID");
                });

            migrationBuilder.CreateTable(
                name: "rekesz",
                columns: table => new
                {
                    CompartmentID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StoragedComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Col = table.Column<int>(type: "int", nullable: false),
                    Bracket = table.Column<int>(type: "int", nullable: false),
                    MaximumPiece = table.Column<int>(type: "int", nullable: false),
                    StoragedPiece = table.Column<int>(type: "int", nullable: true),
                    FKComponentID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rekesz", x => x.CompartmentID);
                    table.ForeignKey(
                        name: "FK_rekesz_alkatresz_FKComponentID",
                        column: x => x.FKComponentID,
                        principalTable: "alkatresz",
                        principalColumn: "ComponentID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_alkatresz_FKPackageID",
                table: "alkatresz",
                column: "FKPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_CoworkerProject_ProjectsProjectID",
                table: "CoworkerProject",
                column: "ProjectsProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_folyamat_FKProcess",
                table: "folyamat",
                column: "FKProcess",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_jogosultsag_FKPermissionName",
                table: "jogosultsag",
                column: "FKPermissionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projekt_FKCustomerID",
                table: "projekt",
                column: "FKCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_projekt_csomag_FKProjectID",
                table: "projekt_csomag",
                column: "FKProjectID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rekesz_FKComponentID",
                table: "rekesz",
                column: "FKComponentID",
                unique: true,
                filter: "[FKComponentID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoworkerProject");

            migrationBuilder.DropTable(
                name: "folyamat");

            migrationBuilder.DropTable(
                name: "jogosultsag");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "rekesz");

            migrationBuilder.DropTable(
                name: "szemelyi_adat");

            migrationBuilder.DropTable(
                name: "alkatresz");

            migrationBuilder.DropTable(
                name: "munkatars_fo");

            migrationBuilder.DropTable(
                name: "projekt_csomag");

            migrationBuilder.DropTable(
                name: "projekt");

            migrationBuilder.DropTable(
                name: "megrendelo");
        }
    }
}
