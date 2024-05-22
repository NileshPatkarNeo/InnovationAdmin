using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SysPref_GeneralBehaviour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "SysPref_GeneralBehaviour",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "SysPref_GeneralBehaviour",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "SysPref_GeneralBehaviour",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SysPref_GeneralBehaviour");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "SysPref_GeneralBehaviour");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "SysPref_GeneralBehaviour");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "SysPref_GeneralBehaviour");
        }
    }
}
