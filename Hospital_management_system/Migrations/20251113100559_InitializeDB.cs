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
                name: "tbl_users",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    username = table.Column<string>(type: "varchar(150)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false),
                    staff_id = table.Column<string>(type: "varchar(150)", nullable: false),
                    code = table.Column<string>(type: "varchar(150)", nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_users", x => x.user_id);
                    table.CheckConstraint("CHK_CODE_NOT_EMPTY2", "LTRIM(RTRIM(ISNULL([Code], ''))) <> ''");
                    table.CheckConstraint("CHK_NAME_NOT_EMPTY2", "LTRIM(RTRIM(Username)) <> ''");
                    table.ForeignKey(
                        name: "FK_tbl_users_tbl_staffs_staff_id",
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
                    { "2883fe52-f4ca-4ce2-9999-6c0280668b2f", "ORTH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bone and Joint Department", true, false, "Orthopedics", null },
                    { "4aa491b1-97cb-4189-8e03-d4ea8c27af6d", "CAD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heart and Cardiovascular Department", true, false, "Cardiology", null },
                    { "4e795955-b97a-4f02-b6bd-334df9f79e47", "GM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General Health Department", true, false, "General Medicine", null },
                    { "63347532-a564-4e23-a5d9-c7de4ef82da0", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", true, false, "IT", null },
                    { "80655e05-0aa7-4feb-860e-32ac14a19864", "PED", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children Health Department", true, false, "Pediatrics", null },
                    { "d3200872-4f52-4982-b1a4-0ed85ee3f927", "EMG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emergency Department", true, false, "Emergency", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_staffs",
                columns: new[] { "staff_id", "address", "code", "created_at", "dob", "department_id", "email", "firstname", "gender", "hired_date", "is_active", "is_deleted", "lastname", "phonenumber", "position", "salary", "updated_at" },
                values: new object[,]
                {
                    { "2db25790-c22a-4adb-8f3b-8e3a7b94d851", "456 Oak Ave", "S002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1975-08-20 00:00:00", "4e795955-b97a-4f02-b6bd-334df9f79e47", "bob.johnson@hms.com", "Bob", 0, new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Johnson", "555-2222", "Nurse", 0m, null },
                    { "83f71025-693f-4067-9b85-84232d4bdce6", "202 Secret Rd", "S006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2004-01-01 00:00:00", "63347532-a564-4e23-a5d9-c7de4ef82da0", "tola.seyha@hms.com", "Seyha", 0, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Tola", "1111-1111", "Administrator", 0m, null },
                    { "92c7323b-d3c2-4024-826c-2a6d4f357c1c", "101 Hero Way", "S004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1982-11-03 00:00:00", "2883fe52-f4ca-4ce2-9999-6c0280668b2f", "diana.prince@hms.com", "Diana", 1, new DateTime(2012, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Prince", "555-4444", "Technician", 0m, null },
                    { "991d5722-d08f-4206-b782-80067da7c4b2", "123 Main St", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1980-05-15 00:00:00", "4aa491b1-97cb-4189-8e03-d4ea8c27af6d", "alice.smith@hms.com", "Alice", 1, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Smith", "555-1111", "Doctor", 0m, null },
                    { "bd1a58da-9479-4f52-802e-90e774249411", "202 Secret Rd", "S005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1995-02-28 00:00:00", "d3200872-4f52-4982-b1a4-0ed85ee3f927", "eve.adams@hms.com", "Eve", 1, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Adams", "555-5555", "Receptionist", 0m, null },
                    { "cb842b1f-e86c-46f0-9176-c7cf53f32d1a", "789 Pine Ln", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-01-25 00:00:00", "80655e05-0aa7-4feb-860e-32ac14a19864", "charlie.brown@hms.com", "Charlie", 0, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Brown", "555-3333", "Doctor", 0m, null },
                    { "f80785eb-4de2-4dd6-9467-f3f0df47a952", "202 Secret Rd", "S007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2005-01-01 00:00:00", "63347532-a564-4e23-a5d9-c7de4ef82da0", "tor.soklumor@hms.com", "Soklumor", 0, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Tor", "2222-2222", "IT", 0m, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_doctors",
                columns: new[] { "doctor_id", "code", "created_at", "is_active", "is_deleted", "license_number", "specialization", "staff_id", "stopped_work", "updated_at", "years_of_experience " },
                values: new object[,]
                {
                    { "7f760449-40eb-4483-8a34-095bc94c4b46", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-PED-001", "Pediatrics", "cb842b1f-e86c-46f0-9176-c7cf53f32d1a", false, null, 10 },
                    { "f23d761d-82be-42e1-8bc8-19392ed61b62", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-CARD-001", "Cardiology", "991d5722-d08f-4206-b782-80067da7c4b2", false, null, 15 }
                });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "code", "created_at", "is_active", "is_deleted", "password", "staff_id", "updated_at", "username" },
                values: new object[,]
                {
                    { "00ea1daf-21ce-49c7-a12e-1b3e31b2257c", "S007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "admin", "f80785eb-4de2-4dd6-9467-f3f0df47a952", null, "Lumor" },
                    { "b2d43c94-c5d0-4d9c-b05f-d27c25a6aaba", "S006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "123456", "83f71025-693f-4067-9b85-84232d4bdce6", null, "Seyha" }
                });

            migrationBuilder.InsertData(
                table: "tbl_patients",
                columns: new[] { "patient_id", "address", "code", "created_at", "dob", "doctor_id", "email", "firstname", "gender", "is_active", "is_deleted", "lastname", "phonenumber", "sickness", "updated_at" },
                values: new object[,]
                {
                    { "23da1e1f-96fd-446e-9568-473762b2049d", "303 River St", "P001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1960-03-10 00:00:00", "f23d761d-82be-42e1-8bc8-19392ed61b62", "frank.white@example.com", "Frank", 0, true, false, "White", "555-6666", "Headache", null },
                    { "847ba0b5-b4c8-4666-9063-c047f89ed82b", "404 Lake Rd", "P002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2018-07-01 00:00:00", "7f760449-40eb-4483-8a34-095bc94c4b46", "grace.black@example.com", "Grace", 1, true, false, "Black", "555-7777", "Fatigue", null },
                    { "d2235564-74c6-4879-a5d6-8e464b062cd3", "505 Mountain View", "P003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-12-25 00:00:00", "f23d761d-82be-42e1-8bc8-19392ed61b62", "henry.green@example.com", "Henry", 0, true, false, "Green", "555-8888", "Cold", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_departments_code",
                table: "tbl_departments",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0 AND [code] <> ''");

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
                filter: "[is_deleted] = 0 AND [license_number] <> ''");

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_code",
                table: "tbl_users",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_staff_id",
                table: "tbl_users",
                column: "staff_id",
                unique: true,
                filter: "[is_deleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_users_username",
                table: "tbl_users",
                column: "username",
                unique: true,
                filter: "[is_deleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_patients");

            migrationBuilder.DropTable(
                name: "tbl_users");

            migrationBuilder.DropTable(
                name: "tbl_doctors");

            migrationBuilder.DropTable(
                name: "tbl_staffs");

            migrationBuilder.DropTable(
                name: "tbl_departments");
        }
    }
}
