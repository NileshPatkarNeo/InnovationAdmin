using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[] { new Guid("253c75d5-32af-4dbf-ab63-1af449bde7bd"), "1", "en", "{PropertyName} is required.", "Error" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[] { new Guid("ed0cc6b6-11f4-4512-a441-625941917502"), "2", "en", "{PropertyName} must not exceed {MaxLength} characters.", "Error" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Code", "Language", "MessageContent", "Type" },
                values: new object[] { new Guid("fafe649a-3e2a-4153-8fd8-9dcd0b87e6d8"), "3", "en", "An event with the same name and date already exists.", "Error" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
