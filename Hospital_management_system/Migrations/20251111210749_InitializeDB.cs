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
                    { "3b9c81f3-b692-4c3c-8184-b5b6a3a6d136", "EMG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emergency Department", true, false, "Emergency", null },
                    { "5b4f0ffd-9906-40f5-ab14-198f91b8a978", "CAD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heart and Cardiovascular Department", true, false, "Cardiology", null },
                    { "c63c5832-ddb1-4cf6-83c4-0611cf1ccaf7", "PED", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children Health Department", true, false, "Pediatrics", null },
                    { "d98dd393-bfdb-4a5e-ac38-48d275013551", "GM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General Health Department", true, false, "General Medicine", null },
                    { "fbb13a92-145b-4a6e-a8d6-3921a37c105a", "ORTH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bone and Joint Department", true, false, "Orthopedics", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_staffs",
                columns: new[] { "staff_id", "address", "code", "created_at", "dob", "department_id", "email", "firstname", "gender", "hired_date", "is_active", "is_deleted", "lastname", "phonenumber", "position", "salary", "updated_at" },
                values: new object[,]
                {
                    { "5c470782-4fd0-4a3b-ba2c-1dd37db8f244", "123 Main St", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1980-05-15 00:00:00", "5b4f0ffd-9906-40f5-ab14-198f91b8a978", "alice.smith@hms.com", "Alice", 1, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Smith", "555-1111", "Nurse", 0m, null },
                    { "9bf0da55-3b7d-41e8-86f6-5fba213b6719", "789 Pine Ln", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-01-25 00:00:00", "c63c5832-ddb1-4cf6-83c4-0611cf1ccaf7", "charlie.brown@hms.com", "Charlie", 0, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Brown", "555-3333", "Nurse", 0m, null },
                    { "a18162d3-4ad9-4342-b0fd-c67c7ee20fa2", "456 Oak Ave", "S002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1975-08-20 00:00:00", "d98dd393-bfdb-4a5e-ac38-48d275013551", "bob.johnson@hms.com", "Bob", 0, new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Johnson", "555-2222", "Administrator", 0m, null },
                    { "b034f4fa-231b-4c4b-8f79-3b0c0a855843", "202 Secret Rd", "S005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1995-02-28 00:00:00", "3b9c81f3-b692-4c3c-8184-b5b6a3a6d136", "eve.adams@hms.com", "Eve", 1, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Adams", "555-5555", "Receptionist", 0m, null },
                    { "e664bff5-021b-407c-90d3-4df9a20a5a2f", "101 Hero Way", "S004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1982-11-03 00:00:00", "fbb13a92-145b-4a6e-a8d6-3921a37c105a", "diana.prince@hms.com", "Diana", 1, new DateTime(2012, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Prince", "555-4444", "Technician", 0m, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_doctors",
                columns: new[] { "doctor_id", "code", "created_at", "is_active", "is_deleted", "license_number", "specialization", "staff_id", "stopped_work", "updated_at", "years_of_experience " },
                values: new object[,]
                {
                    { "592a5e0f-5a2a-43d4-8a50-9733381a4451", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-PED-001", "Pediatrics", "9bf0da55-3b7d-41e8-86f6-5fba213b6719", false, null, 10 },
                    { "970fcbb7-f956-41a6-9a6b-9999dc026732", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-CARD-001", "Cardiology", "5c470782-4fd0-4a3b-ba2c-1dd37db8f244", false, null, 15 }
                });

            migrationBuilder.InsertData(
                table: "tbl_patients",
                columns: new[] { "patient_id", "address", "code", "created_at", "dob", "doctor_id", "email", "firstname", "gender", "is_active", "is_deleted", "lastname", "phonenumber", "sickness", "updated_at" },
                values: new object[,]
                {
                    { "959ac403-97ee-483e-95aa-2ccd3aa8a329", "303 River St", "P001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1960-03-10 00:00:00", "970fcbb7-f956-41a6-9a6b-9999dc026732", "frank.white@example.com", "Frank", 0, true, false, "White", "555-6666", "Headache", null },
                    { "9e97f934-343c-456f-b409-0e32c3a2d2d0", "505 Mountain View", "P003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-12-25 00:00:00", "970fcbb7-f956-41a6-9a6b-9999dc026732", "henry.green@example.com", "Henry", 0, true, false, "Green", "555-8888", "Cold", null },
                    { "d13ffa61-6538-467e-8b59-9c135d24080d", "404 Lake Rd", "P002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2018-07-01 00:00:00", "592a5e0f-5a2a-43d4-8a50-9733381a4451", "grace.black@example.com", "Grace", 1, true, false, "Black", "555-7777", "Fatigue", null }
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
