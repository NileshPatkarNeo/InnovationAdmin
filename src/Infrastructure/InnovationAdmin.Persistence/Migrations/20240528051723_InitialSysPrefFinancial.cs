using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class InitialSysPrefFinancial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysPrefFinancials",
                columns: table => new
                {
                    FinancialID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultPaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastCheckNo = table.Column<int>(type: "int", nullable: false),
                    ClaimAgeCollectionStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClaimAgeCollectionEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DefaultReceiptBatchDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClaimPaidThreshold = table.Column<int>(type: "int", nullable: false),
                    ClaimStatusWriteOff = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DaysToBlock = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysPrefFinancials", x => x.FinancialID);
                    table.ForeignKey(
                        name: "FK_SysPrefFinancials_SysPrefCompanies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "SysPrefCompanies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SysPrefFinancials_CompanyID",
                table: "SysPrefFinancials",
                column: "CompanyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysPrefFinancials");
        }
    }
}
