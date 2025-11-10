using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientForMVPAndRemoveAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_appointments");

            migrationBuilder.DropColumn(
                name: "allergies",
                table: "tbl_patients");

            migrationBuilder.DropColumn(
                name: "blood_type",
                table: "tbl_patients");

            migrationBuilder.DropColumn(
                name: "emergency_contact_name",
                table: "tbl_patients");

            migrationBuilder.DropColumn(
                name: "emergency_contact_phone",
                table: "tbl_patients");

            migrationBuilder.AddColumn<string>(
                name: "doctor_id",
                table: "tbl_patients",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sickness",
                table: "tbl_patients",
                type: "varchar(150)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_doctor_id",
                table: "tbl_patients",
                column: "doctor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_patients_tbl_doctors_doctor_id",
                table: "tbl_patients",
                column: "doctor_id",
                principalTable: "tbl_doctors",
                principalColumn: "doctor_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_patients_tbl_doctors_doctor_id",
                table: "tbl_patients");

            migrationBuilder.DropIndex(
                name: "IX_tbl_patients_doctor_id",
                table: "tbl_patients");

            migrationBuilder.DropColumn(
                name: "doctor_id",
                table: "tbl_patients");

            migrationBuilder.DropColumn(
                name: "sickness",
                table: "tbl_patients");

            migrationBuilder.AddColumn<string>(
                name: "allergies",
                table: "tbl_patients",
                type: "varchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "blood_type",
                table: "tbl_patients",
                type: "varchar(5)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emergency_contact_name",
                table: "tbl_patients",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emergency_contact_phone",
                table: "tbl_patients",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tbl_appointments",
                columns: table => new
                {
                    appointment_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    doctor_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    patient_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    appointment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    duration_minutes = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    notes = table.Column<string>(type: "varchar(500)", nullable: true),
                    purpose = table.Column<string>(type: "varchar(200)", nullable: true),
                    status = table.Column<string>(type: "varchar(20)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "tbl_doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_appointments_tbl_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "tbl_patients",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_appointment_date",
                table: "tbl_appointments",
                column: "appointment_date");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_doctor_id",
                table: "tbl_appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_appointments_patient_id",
                table: "tbl_appointments",
                column: "patient_id");
        }
    }
}
