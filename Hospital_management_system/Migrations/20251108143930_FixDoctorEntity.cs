using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class FixDoctorEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "tbl_doctors",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "tbl_doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "tbl_doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "tbl_doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "tbl_doctors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "tbl_doctors");
        }
    }
}
