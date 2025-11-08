using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hired_date",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "tbl_doctors");

            migrationBuilder.AlterColumn<int>(
                name: "gender",
                table: "tbl_staffs",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "gender",
                table: "tbl_patients",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "tbl_staffs",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "tbl_patients",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "hired_date",
                table: "tbl_doctors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "salary",
                table: "tbl_doctors",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
