using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RHM_Napv02_projekt_server.Migrations
{
    public partial class Initial : Migration
    {
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
                name: "munkatars_adat",
                columns: table => new
                {
                    CoworkerTel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoworkerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoworkerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_munkatars_adat", x => x.CoworkerTel);
                });

            migrationBuilder.CreateTable(
                name: "munkatars_jogosultsag",
                columns: table => new
                {
                    CoworkerPermissionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_munkatars_jogosultsag", x => x.CoworkerPermissionName);
                });

            migrationBuilder.CreateTable(
                name: "munkatars_login",
                columns: table => new
                {
                    CoworkerLoginID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_munkatars_login", x => x.CoworkerLoginID);
                });

            migrationBuilder.CreateTable(
                name: "projekt",
                columns: table => new
                {
                    ProjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectCustomerID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekt", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_projekt_megrendelo_ProjectCustomerID",
                        column: x => x.ProjectCustomerID,
                        principalTable: "megrendelo",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "munkatars_fo",
                columns: table => new
                {
                    CoworkerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoworkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoworkerPosition = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CoworkerTel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectCoworkerID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoworkerLoginID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_munkatars_fo", x => x.CoworkerId);
                    table.ForeignKey(
                        name: "FK_munkatars_fo_munkatars_adat_CoworkerTel",
                        column: x => x.CoworkerTel,
                        principalTable: "munkatars_adat",
                        principalColumn: "CoworkerTel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_munkatars_fo_munkatars_jogosultsag_CoworkerPosition",
                        column: x => x.CoworkerPosition,
                        principalTable: "munkatars_jogosultsag",
                        principalColumn: "CoworkerPermissionName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_munkatars_fo_munkatars_login_CoworkerLoginID",
                        column: x => x.CoworkerLoginID,
                        principalTable: "munkatars_login",
                        principalColumn: "CoworkerLoginID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "folyamat",
                columns: table => new
                {
                    ProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcessName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_folyamat", x => x.ProcessID);
                    table.ForeignKey(
                        name: "FK_folyamat_projekt_ProcessName",
                        column: x => x.ProcessName,
                        principalTable: "projekt",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projekt_csomag",
                columns: table => new
                {
                    ProjectPackageID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PackageComponentName = table.Column<int>(type: "int", nullable: false),
                    RequiredPiece = table.Column<int>(type: "int", nullable: false),
                    PackageProjectID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekt_csomag", x => x.ProjectPackageID);
                    table.ForeignKey(
                        name: "FK_projekt_csomag_projekt_ProjectPackageID",
                        column: x => x.ProjectPackageID,
                        principalTable: "projekt",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoworkerMainProject",
                columns: table => new
                {
                    CoworkerMainsCoworkerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectsProjectID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoworkerMainProject", x => new { x.CoworkerMainsCoworkerId, x.ProjectsProjectID });
                    table.ForeignKey(
                        name: "FK_CoworkerMainProject_munkatars_fo_CoworkerMainsCoworkerId",
                        column: x => x.CoworkerMainsCoworkerId,
                        principalTable: "munkatars_fo",
                        principalColumn: "CoworkerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoworkerMainProject_projekt_ProjectsProjectID",
                        column: x => x.ProjectsProjectID,
                        principalTable: "projekt",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alkatresz",
                columns: table => new
                {
                    ComponentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ComponentID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPiece = table.Column<int>(type: "int", nullable: false),
                    Piece = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ProjectPackageComponentID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alkatresz", x => x.ComponentName);
                    table.ForeignKey(
                        name: "FK_alkatresz_projekt_csomag_ProjectPackageComponentID",
                        column: x => x.ProjectPackageComponentID,
                        principalTable: "projekt_csomag",
                        principalColumn: "ProjectPackageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rekesz",
                columns: table => new
                {
                    CompartmentNr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Col = table.Column<int>(type: "int", nullable: false),
                    Bracket = table.Column<int>(type: "int", nullable: false),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoragedPiece = table.Column<float>(type: "real", nullable: false),
                    CompartmentComponentID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rekesz", x => x.CompartmentNr);
                    table.ForeignKey(
                        name: "FK_rekesz_alkatresz_CompartmentComponentID",
                        column: x => x.CompartmentComponentID,
                        principalTable: "alkatresz",
                        principalColumn: "ComponentName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alkatresz_ProjectPackageComponentID",
                table: "alkatresz",
                column: "ProjectPackageComponentID");

            migrationBuilder.CreateIndex(
                name: "IX_CoworkerMainProject_ProjectsProjectID",
                table: "CoworkerMainProject",
                column: "ProjectsProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_folyamat_ProcessName",
                table: "folyamat",
                column: "ProcessName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_munkatars_fo_CoworkerLoginID",
                table: "munkatars_fo",
                column: "CoworkerLoginID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_munkatars_fo_CoworkerPosition",
                table: "munkatars_fo",
                column: "CoworkerPosition",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_munkatars_fo_CoworkerTel",
                table: "munkatars_fo",
                column: "CoworkerTel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projekt_ProjectCustomerID",
                table: "projekt",
                column: "ProjectCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_rekesz_CompartmentComponentID",
                table: "rekesz",
                column: "CompartmentComponentID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoworkerMainProject");

            migrationBuilder.DropTable(
                name: "folyamat");

            migrationBuilder.DropTable(
                name: "rekesz");

            migrationBuilder.DropTable(
                name: "munkatars_fo");

            migrationBuilder.DropTable(
                name: "alkatresz");

            migrationBuilder.DropTable(
                name: "munkatars_adat");

            migrationBuilder.DropTable(
                name: "munkatars_jogosultsag");

            migrationBuilder.DropTable(
                name: "munkatars_login");

            migrationBuilder.DropTable(
                name: "projekt_csomag");

            migrationBuilder.DropTable(
                name: "projekt");

            migrationBuilder.DropTable(
                name: "megrendelo");
        }
    }
}
