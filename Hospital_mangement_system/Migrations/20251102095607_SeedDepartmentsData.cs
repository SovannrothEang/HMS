using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_mangement_system.Migrations
{
    /// <inheritdoc />
    public partial class SeedDepartmentsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_code",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "department_id", "created_at", "description", "is_active", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { "1271cd4c-7bc9-4670-add9-df60cea84819", new DateTime(2025, 11, 2, 9, 56, 6, 994, DateTimeKind.Utc).AddTicks(7508), "Children Health Department", true, false, "Pediatrics", null },
                    { "557111a9-abf3-4088-9523-514b825dfecb", new DateTime(2025, 11, 2, 9, 56, 6, 994, DateTimeKind.Utc).AddTicks(7515), "Bone and Joint Department", true, false, "Orthopedics", null },
                    { "ab95c65e-cd21-4364-9333-d68c6e324a20", new DateTime(2025, 11, 2, 9, 56, 6, 994, DateTimeKind.Utc).AddTicks(7521), "General Health Department", true, false, "General Medicine", null },
                    { "ea4f9008-bc9d-4d68-ba08-8d734f0213dd", new DateTime(2025, 11, 2, 9, 56, 6, 994, DateTimeKind.Utc).AddTicks(7438), "Heart and Cardiovascular Department", true, false, "Cardiology", null },
                    { "ed20f006-2eb6-4a99-a41c-472c5ad7c164", new DateTime(2025, 11, 2, 9, 56, 6, 994, DateTimeKind.Utc).AddTicks(7526), "Emergency Department", true, false, "Emergency", null }
                });

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_staffs",
                sql: "Code <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors",
                sql: "Code <> ''");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "department_id",
                keyValue: "1271cd4c-7bc9-4670-add9-df60cea84819");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "department_id",
                keyValue: "557111a9-abf3-4088-9523-514b825dfecb");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "department_id",
                keyValue: "ab95c65e-cd21-4364-9333-d68c6e324a20");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "department_id",
                keyValue: "ea4f9008-bc9d-4d68-ba08-8d734f0213dd");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "department_id",
                keyValue: "ed20f006-2eb6-4a99-a41c-472c5ad7c164");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "Departments",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_code",
                table: "Departments",
                column: "code",
                unique: true);
        }
    }
}
