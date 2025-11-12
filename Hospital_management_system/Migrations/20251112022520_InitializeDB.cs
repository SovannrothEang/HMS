using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_departments",
                columns: table => new
                {
                    department_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    description = table.Column<string>(type: "varchar(500)", nullable: true),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_departments", x => x.department_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_staffs",
                columns: table => new
                {
                    staff_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    position = table.Column<string>(type: "varchar(150)", nullable: false),
                    hired_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    department_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    firstname = table.Column<string>(type: "varchar(70)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    lastname = table.Column<string>(type: "varchar(70)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    dob = table.Column<string>(type: "varchar(150)", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    address = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_staffs", x => x.staff_id);
                    table.CheckConstraint("CHK_CODE_NOT_EMPTY1", "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");
                    table.CheckConstraint("CHK_NAME_NOT_EMPTY1", "LTRIM(RTRIM(FirstName + ' ' + LastName)) <> ''");
                    table.ForeignKey(
                        name: "FK_tbl_staffs_tbl_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "tbl_departments",
                        principalColumn: "department_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_doctors",
                columns: table => new
                {
                    doctor_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    specialization = table.Column<string>(type: "varchar(150)", nullable: false),
                    license_number = table.Column<string>(type: "varchar(150)", nullable: false),
                    years_of_experience = table.Column<int>(name: "years_of_experience ", type: "integer", nullable: false),
                    stopped_work = table.Column<bool>(type: "bit", nullable: false),
                    staff_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_doctors", x => x.doctor_id);
                    table.ForeignKey(
                        name: "FK_tbl_doctors_tbl_staffs_staff_id",
                        column: x => x.staff_id,
                        principalTable: "tbl_staffs",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_patients",
                columns: table => new
                {
                    patient_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    sickness = table.Column<string>(type: "varchar(150)", nullable: false),
                    doctor_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    firstname = table.Column<string>(type: "varchar(70)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    lastname = table.Column<string>(type: "varchar(70)", nullable: false, collation: "SQL_Latin1_General_CP850_BIN"),
                    dob = table.Column<string>(type: "varchar(150)", nullable: false),
                    gender = table.Column<int>(type: "integer", nullable: false),
                    phonenumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    address = table.Column<string>(type: "varchar(50)", nullable: true),
                    email = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_patients", x => x.patient_id);
                    table.CheckConstraint("CHK_CODE_NOT_EMPTY", "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");
                    table.CheckConstraint("CHK_NAME_NOT_EMPTY", "LTRIM(RTRIM(FirstName + ' ' + LastName)) <> ''");
                    table.ForeignKey(
                        name: "FK_tbl_patients_tbl_doctors_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "tbl_doctors",
                        principalColumn: "doctor_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tbl_departments",
                columns: new[] { "department_id", "code", "created_at", "description", "is_active", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { "6c0911bd-028f-428b-8bbd-c9022a4fd283", "GM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General Health Department", true, false, "General Medicine", null },
                    { "7cfd457a-d85d-4f92-af68-3faeae8e082e", "ORTH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bone and Joint Department", true, false, "Orthopedics", null },
                    { "d8f9eda7-f2b8-4a62-82b6-977a85f09019", "PED", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children Health Department", true, false, "Pediatrics", null },
                    { "e50fa8ab-8e3e-476e-8334-bc7ac06ac455", "CAD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heart and Cardiovascular Department", true, false, "Cardiology", null },
                    { "f9e3baff-3824-4922-9eb3-eefa17db75d4", "EMG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emergency Department", true, false, "Emergency", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_staffs",
                columns: new[] { "staff_id", "address", "code", "created_at", "dob", "department_id", "email", "firstname", "gender", "hired_date", "is_active", "is_deleted", "lastname", "phonenumber", "position", "salary", "updated_at" },
                values: new object[,]
                {
                    { "5c826fc3-0269-4032-88d7-098f3b860f0d", "789 Pine Ln", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-01-25 00:00:00", "d8f9eda7-f2b8-4a62-82b6-977a85f09019", "charlie.brown@hms.com", "Charlie", 0, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Brown", "555-3333", "Doctor", 0m, null },
                    { "6611603a-26b3-45bb-8da0-5b0ca76eb065", "456 Oak Ave", "S002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1975-08-20 00:00:00", "6c0911bd-028f-428b-8bbd-c9022a4fd283", "bob.johnson@hms.com", "Bob", 0, new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Johnson", "555-2222", "Administrator", 0m, null },
                    { "9f6055bf-c990-43cc-901d-2e669b03ee65", "101 Hero Way", "S004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1982-11-03 00:00:00", "7cfd457a-d85d-4f92-af68-3faeae8e082e", "diana.prince@hms.com", "Diana", 1, new DateTime(2012, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Prince", "555-4444", "Technician", 0m, null },
                    { "ac25e473-b4be-4036-ae2e-c263f160441a", "123 Main St", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1980-05-15 00:00:00", "e50fa8ab-8e3e-476e-8334-bc7ac06ac455", "alice.smith@hms.com", "Alice", 1, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Smith", "555-1111", "Doctor", 0m, null },
                    { "eea784b8-f664-47c7-b328-3beb23eefac7", "202 Secret Rd", "S005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1995-02-28 00:00:00", "f9e3baff-3824-4922-9eb3-eefa17db75d4", "eve.adams@hms.com", "Eve", 1, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Adams", "555-5555", "Receptionist", 0m, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_doctors",
                columns: new[] { "doctor_id", "code", "created_at", "is_active", "is_deleted", "license_number", "specialization", "staff_id", "stopped_work", "updated_at", "years_of_experience " },
                values: new object[,]
                {
                    { "06a79d68-4312-4982-b891-3fcccef4cd8c", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-PED-001", "Pediatrics", "5c826fc3-0269-4032-88d7-098f3b860f0d", false, null, 10 },
                    { "f8aea8bd-f4a2-4369-a175-8edc7fe90529", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-CARD-001", "Cardiology", "ac25e473-b4be-4036-ae2e-c263f160441a", false, null, 15 }
                });

            migrationBuilder.InsertData(
                table: "tbl_patients",
                columns: new[] { "patient_id", "address", "code", "created_at", "dob", "doctor_id", "email", "firstname", "gender", "is_active", "is_deleted", "lastname", "phonenumber", "sickness", "updated_at" },
                values: new object[,]
                {
                    { "b81b3575-1b36-4480-9a19-485307294920", "303 River St", "P001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1960-03-10 00:00:00", "f8aea8bd-f4a2-4369-a175-8edc7fe90529", "frank.white@example.com", "Frank", 0, true, false, "White", "555-6666", "Headache", null },
                    { "c86e112f-c75e-4a16-b188-bdb652e7602e", "404 Lake Rd", "P002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2018-07-01 00:00:00", "06a79d68-4312-4982-b891-3fcccef4cd8c", "grace.black@example.com", "Grace", 1, true, false, "Black", "555-7777", "Fatigue", null },
                    { "d9c0c301-356c-4439-b0a0-973d9f9be26f", "505 Mountain View", "P003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-12-25 00:00:00", "f8aea8bd-f4a2-4369-a175-8edc7fe90529", "henry.green@example.com", "Henry", 0, true, false, "Green", "555-8888", "Cold", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_departments_name",
                table: "tbl_departments",
                column: "name",
                unique: true,
                filter: "[is_deleted] = 0 AND [name] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors",
                column: "license_number",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_specialization",
                table: "tbl_doctors",
                column: "specialization");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_staff_id",
                table: "tbl_doctors",
                column: "staff_id",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_code",
                table: "tbl_patients",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_doctor_id",
                table: "tbl_patients",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_patients_firstname_lastname",
                table: "tbl_patients",
                columns: new[] { "firstname", "lastname" });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_code",
                table: "tbl_staffs",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_staffs_department_id",
                table: "tbl_staffs",
                column: "department_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_patients");

            migrationBuilder.DropTable(
                name: "tbl_doctors");

            migrationBuilder.DropTable(
                name: "tbl_staffs");

            migrationBuilder.DropTable(
                name: "tbl_departments");
        }
    }
}
