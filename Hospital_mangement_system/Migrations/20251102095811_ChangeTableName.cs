using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_mangement_system.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "tbl_departments");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_name",
                table: "tbl_departments",
                newName: "IX_tbl_departments_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "tbl_departments",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_departments_name",
                table: "Departments",
                newName: "IX_Departments_name");
        }
    }
}
