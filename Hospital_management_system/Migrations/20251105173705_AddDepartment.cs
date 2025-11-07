using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_appointments_tbl_staffs_doctor_id",
                table: "tbl_appointments");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY2",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY2",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_patients");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY1",
                table: "tbl_patients");

            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_code",
                table: "tbl_doctors");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "address",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "code",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "dob",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "email",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "firstname",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "phonenumber",
                table: "tbl_doctors");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "tbl_doctors");

            migrationBuilder.RenameColumn(
                name: "years_of_experiense ",
                table: "tbl_doctors",
                newName: "years_of_experience ");

            migrationBuilder.AddColumn<string>(
                name: "allergies",
                table: "tbl_patients",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "tbl_departments",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "tbl_departments",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "tbl_appointments",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_staffs",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY1",
                table: "tbl_staffs",
                sql: "LTRIM(RTRIM(FirstName + ' ' + LastName)) <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_firstname_lastname",
                table: "tbl_patients",
                columns: new[] { "firstname", "lastname" });

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_patients",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY",
                table: "tbl_patients",
                sql: "LTRIM(RTRIM(FirstName + ' ' + LastName)) <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_appointment_date",
                table: "tbl_appointments",
                column: "appointment_date");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_appointments_tbl_doctors_doctor_id",
                table: "tbl_appointments",
                column: "doctor_id",
                principalTable: "tbl_doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_appointments_tbl_doctors_doctor_id",
                table: "tbl_appointments");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_staffs");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY1",
                table: "tbl_staffs");

            migrationBuilder.DropIndex(
                name: "IX_tbl_patients_firstname_lastname",
                table: "tbl_patients");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_patients");

            migrationBuilder.DropCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY",
                table: "tbl_patients");

            migrationBuilder.DropIndex(
                name: "IX_tbl_appointments_appointment_date",
                table: "tbl_appointments");

            migrationBuilder.DropColumn(
                name: "allergies",
                table: "tbl_patients");

            migrationBuilder.DropColumn(
                name: "code",
                table: "tbl_departments");

            migrationBuilder.DropColumn(
                name: "code",
                table: "tbl_appointments");

            migrationBuilder.RenameColumn(
                name: "years_of_experience ",
                table: "tbl_doctors",
                newName: "years_of_experiense ");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "tbl_doctors",
                type: "varchar(50)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "dob",
                table: "tbl_doctors",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "tbl_doctors",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "tbl_doctors",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "tbl_doctors",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "tbl_doctors",
                type: "varchar(70)",
                nullable: false,
                defaultValue: "",
                collation: "SQL_Latin1_General_CP850_BIN");

            migrationBuilder.AddColumn<string>(
                name: "phonenumber",
                table: "tbl_doctors",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "tbl_doctors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "tbl_departments",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY2",
                table: "tbl_staffs",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY2",
                table: "tbl_staffs",
                sql: "LTRIM(RTRIM(Firstname + ' ' + Lastname)) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY1",
                table: "tbl_patients",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY1",
                table: "tbl_patients",
                sql: "LTRIM(RTRIM(Firstname + ' ' + Lastname)) <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_code",
                table: "tbl_doctors",
                column: "code",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CHK_CODE_NOT_EMPTY",
                table: "tbl_doctors",
                sql: "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");

            migrationBuilder.AddCheckConstraint(
                name: "CHK_NAME_NOT_EMPTY",
                table: "tbl_doctors",
                sql: "LTRIM(RTRIM(Firstname + ' ' + Lastname)) <> ''");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_appointments_tbl_staffs_doctor_id",
                table: "tbl_appointments",
                column: "doctor_id",
                principalTable: "tbl_staffs",
                principalColumn: "staff_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
