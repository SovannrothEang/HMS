using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class AddFilterForSoftDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_staffs_code",
                table: "tbl_staffs");

            migrationBuilder.DropIndex(
                name: "IX_tbl_patients_code",
                table: "tbl_patients");

            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors");

            migrationBuilder.DropIndex(
                name: "IX_tbl_departments_name",
                table: "tbl_departments");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_code",
                table: "tbl_staffs",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_code",
                table: "tbl_patients",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors",
                column: "license_number",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_departments_name",
                table: "tbl_departments",
                column: "name",
                unique: true,
                filter: "[is_deleted] = 0 AND [name] <> ''");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_staffs_code",
                table: "tbl_staffs");

            migrationBuilder.DropIndex(
                name: "IX_tbl_patients_code",
                table: "tbl_patients");

            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors");

            migrationBuilder.DropIndex(
                name: "IX_tbl_departments_name",
                table: "tbl_departments");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_code",
                table: "tbl_staffs",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_code",
                table: "tbl_patients",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors",
                column: "license_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_departments_name",
                table: "tbl_departments",
                column: "name",
                unique: true,
                filter: "name <> ''");
        }
    }
}
