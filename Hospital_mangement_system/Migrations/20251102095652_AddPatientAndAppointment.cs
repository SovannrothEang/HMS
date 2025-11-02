using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_mangement_system.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientAndAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_staffs_fullname",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_staffs");

            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_fullname",
                table: "tbl_doctors");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "fullname",
                table: "tbl_staffs");

            migrationBuilder.DropColumn(
                name: "fullname",
                table: "tbl_doctors");

            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "tbl_staffs",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AddColumn<string>(
                name: "department_id",
                table: "tbl_staffs",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "tbl_staffs",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "tbl_staffs",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "tbl_doctors",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "tbl_doctors",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "tbl_doctors",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.CreateTable(
                name: "tbl_patients",
                columns: table => new
                {
                    patient_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    emergency_contact_name = table.Column<string>(type: "varchar(150)", nullable: true),
                    emergency_contact_phone = table.Column<string>(type: "varchar(20)", nullable: true),
                    blood_type = table.Column<string>(type: "varchar(5)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    firstname = table.Column<string>(type: "varchar(70)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    lastname = table.Column<string>(type: "varchar(70)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    dob = table.Column<string>(type: "varchar(150)", nullable: false),
                    gender = table.Column<string>(type: "varchar(50)", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    address = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_patients", x => x.patient_id);
                    table.CheckConstraint("CHK_CODE_NOT_EMPTY1", "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");
                    table.CheckConstraint("CHK_NAME_NOT_EMPTY1", "LTRIM(RTRIM(Firstname + ' ' + Lastname)) <> ''");
                });

            migrationBuilder.CreateTable(
                name: "tbl_appointments",
                columns: table => new
                {
                    appointment_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    patient_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    doctor_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    appointment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    purpose = table.Column<string>(type: "varchar(200)", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    notes = table.Column<string>(type: "varchar(500)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "tbl_patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_staffs_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "tbl_staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_department_id",
                table: "tbl_staffs",
                column: "department_id");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY2",
                table: "tbl_staffs",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY2",
                table: "tbl_staffs",
                sql: "LTRIM(RTRIM(Firstname + ' ' + Lastname)) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY",
                table: "tbl_doctors",
                sql: "LTRIM(RTRIM(Firstname + ' ' + Lastname)) <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_doctor_id",
                table: "tbl_appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_patient_id",
                table: "tbl_appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_code",
                table: "tbl_patients",
                column: "code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_doctors_tbl_staffs_doctor_id",
                table: "tbl_doctors",
                column: "doctor_id",
                principalTable: "tbl_staffs",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_staffs_tbl_departments_department_id",
                table: "tbl_staffs",
                column: "department_id",
                principalTable: "tbl_departments",
                principalColumn: "department_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_doctors_tbl_staffs_doctor_id",
                table: "tbl_doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_staffs_tbl_departments_department_id",
                table: "tbl_staffs");

            migrationBuilder.DropTable(
                name: "tbl_appointments");

            migrationBuilder.DropTable(
                name: "tbl_patients");

            migrationBuilder.DropIndex(
                name: "IX_tbl_staffs_department_id",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY2",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY2",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "department_id",
                table: "tbl_staffs");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "tbl_staffs");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "tbl_staffs");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "tbl_doctors");

            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "tbl_staffs",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "tbl_staffs",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.AlterColumn<string>(
                name: "phonenumber",
                table: "tbl_doctors",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fullname",
                table: "tbl_doctors",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_fullname",
                table: "tbl_staffs",
                column: "fullname",
                unique: true,
                filter: "fullname <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_staffs",
                sql: "Code <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_fullname",
                table: "tbl_doctors",
                column: "fullname",
                unique: true,
                filter: "fullname <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors",
                sql: "Code <> ''");
        }
    }
}
