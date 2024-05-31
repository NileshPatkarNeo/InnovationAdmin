using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysPrefSecurityEmails",
                columns: table => new
                {
                    SysPrefSecurityEmailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DefaultFromName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultFromAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultReplyToAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DefaultReplyToName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysPrefSecurityEmails", x => x.SysPrefSecurityEmailId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SysPrefSecurityEmails");
        }
    }
}
