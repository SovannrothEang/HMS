using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class FixStaffIdSoftDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors",
                column: "staff_id",
                unique: true,
                filter: "[is_deleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors",
                column: "staff_id",
                unique: true);
        }
    }
}
