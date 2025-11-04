using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    department_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    description = table.Column<string>(type: "varchar(500)", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_doctors",
                columns: table => new
                {
                    doctor_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    specialization = table.Column<string>(type: "varchar(150)", nullable: false),
                    license_number = table.Column<string>(type: "varchar(150)", nullable: false),
                    years_of_experiense = table.Column<int>(name: "years_of_experiense ", type: "integer", nullable: false),
                    hired_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stopped_work = table.Column<bool>(type: "bit", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fullname = table.Column<string>(type: "varchar(255)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    dob = table.Column<string>(type: "varchar(150)", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(150)", nullable: false),
                    gender = table.Column<string>(type: "varchar(50)", nullable: false),
                    address = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_doctors", x => x.doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_staffs",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    position = table.Column<string>(type: "varchar(150)", nullable: false),
                    hired_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fullname = table.Column<string>(type: "varchar(255)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    dob = table.Column<string>(type: "varchar(150)", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(150)", nullable: false),
                    gender = table.Column<string>(type: "varchar(50)", nullable: false),
                    address = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_staffs", x => x.staff_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_code",
                table: "Departments",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_name",
                table: "Departments",
                column: "name",
                unique: true,
                filter: "name <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_code",
                table: "tbl_doctors",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_fullname",
                table: "tbl_doctors",
                column: "fullname",
                unique: true,
                filter: "fullname <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors",
                column: "license_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_specialization",
                table: "tbl_doctors",
                column: "specialization");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_code",
                table: "tbl_staffs",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_fullname",
                table: "tbl_staffs",
                column: "fullname",
                unique: true,
                filter: "fullname <> ''");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "tbl_doctors");

            migrationBuilder.DropTable(
                name: "tbl_staffs");
        }
    }
}
