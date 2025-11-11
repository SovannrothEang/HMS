using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class FixErrorForiegnKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_doctors_tbl_staffs_doctor_id",
                table: "tbl_doctors");

            migrationBuilder.AddColumn<string>(
                name: "staff_id1",
                table: "tbl_doctors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors",
                column: "staff_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_doctors_tbl_staffs_staff_id",
                table: "tbl_doctors",
                column: "staff_id",
                principalTable: "tbl_staffs",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_doctors_tbl_staffs_staff_id",
                table: "tbl_doctors");

            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "staff_id1",
                table: "tbl_doctors");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_doctors_tbl_staffs_doctor_id",
                table: "tbl_doctors",
                column: "doctor_id",
                principalTable: "tbl_staffs",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
