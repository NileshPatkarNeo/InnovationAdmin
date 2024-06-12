using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InnovationAdmin.Persistence.Migrations
{
    public partial class BillingMethodTypeInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BillingMethodTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BillingMethodTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "BillingMethodTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "BillingMethodTypes",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BillingMethodTypes");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BillingMethodTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "BillingMethodTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "BillingMethodTypes");
        }
    }
}
