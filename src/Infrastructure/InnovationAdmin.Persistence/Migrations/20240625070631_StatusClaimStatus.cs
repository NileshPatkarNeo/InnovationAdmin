using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class StatusClaimStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "claimStatuses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "claimStatuses");
        }
    }
}
