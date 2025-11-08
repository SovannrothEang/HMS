using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStaffId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "staff_id",
                table: "tbl_doctors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "staff_id",
                table: "tbl_doctors",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");
        }
    }
}
