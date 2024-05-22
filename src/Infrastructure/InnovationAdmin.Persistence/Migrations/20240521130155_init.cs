using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysPref_GeneralBehaviour",
                columns: table => new
                {
                    Preference_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Auto_Change_Claim_Status = table.Column<bool>(type: "bit", nullable: false),
                    Claim_Status_Receipting = table.Column<bool>(type: "bit", nullable: false),
                    Claim_Status_Payment = table.Column<bool>(type: "bit", nullable: false),
                    Claim_Status_Zero_Paid = table.Column<bool>(type: "bit", nullable: false),
                    Claim_Status_Procare_Claim_Load = table.Column<bool>(type: "bit", nullable: false),
                    Logout_Redirect = table.Column<bool>(type: "bit", nullable: false),
                    Records_Locked_Seconds = table.Column<int>(type: "int", nullable: false),
                    User_Timeout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysPref_GeneralBehaviour", x => x.Preference_ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysPref_GeneralBehaviour");
        }
    }
}
