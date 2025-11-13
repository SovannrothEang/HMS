using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hospital_management_system.Migrations
{
    /// <inheritdoc />
    public partial class UserEntityAndLogin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors");

            migrationBuilder.DeleteData(
                table: "tbl_patients",
                keyColumn: "patient_id",
                keyValue: "b81b3575-1b36-4480-9a19-485307294920");

            migrationBuilder.DeleteData(
                table: "tbl_patients",
                keyColumn: "patient_id",
                keyValue: "c86e112f-c75e-4a16-b188-bdb652e7602e");

            migrationBuilder.DeleteData(
                table: "tbl_patients",
                keyColumn: "patient_id",
                keyValue: "d9c0c301-356c-4439-b0a0-973d9f9be26f");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "6611603a-26b3-45bb-8da0-5b0ca76eb065");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "9f6055bf-c990-43cc-901d-2e669b03ee65");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "eea784b8-f664-47c7-b328-3beb23eefac7");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "6c0911bd-028f-428b-8bbd-c9022a4fd283");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "7cfd457a-d85d-4f92-af68-3faeae8e082e");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "f9e3baff-3824-4922-9eb3-eefa17db75d4");

            migrationBuilder.DeleteData(
                table: "tbl_doctors",
                keyColumn: "doctor_id",
                keyValue: "06a79d68-4312-4982-b891-3fcccef4cd8c");

            migrationBuilder.DeleteData(
                table: "tbl_doctors",
                keyColumn: "doctor_id",
                keyValue: "f8aea8bd-f4a2-4369-a175-8edc7fe90529");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "5c826fc3-0269-4032-88d7-098f3b860f0d");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "ac25e473-b4be-4036-ae2e-c263f160441a");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "d8f9eda7-f2b8-4a62-82b6-977a85f09019");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "e50fa8ab-8e3e-476e-8334-bc7ac06ac455");

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

            migrationBuilder.InsertData(
                table: "tbl_departments",
                columns: new[] { "department_id", "code", "created_at", "description", "is_active", "is_deleted", "name", "updated_at" },
                values: new object[,]
                {
                    { "1077b6fa-06fa-4974-b36e-a75638ba6ea4", "ORTH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bone and Joint Department", true, false, "Orthopedics", null },
                    { "1642e3af-542f-46f0-9bcc-c1f1b7550386", "CAD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heart and Cardiovascular Department", true, false, "Cardiology", null },
                    { "2a5d58b7-8fb8-4ad0-aa8c-6ad25d8d8cbb", "EMG", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emergency Department", true, false, "Emergency", null },
                    { "38caf774-3b85-4d0d-8a08-ba7e14b8687e", "IT", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Information Technology", true, false, "IT", null },
                    { "91c6b605-97c1-4657-971c-e2e47c02a517", "GM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General Health Department", true, false, "General Medicine", null },
                    { "dedf8e44-dce2-482b-8b88-ec68b384a14e", "PED", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Children Health Department", true, false, "Pediatrics", null }
                });

            migrationBuilder.InsertData(
                table: "tbl_staffs",
                columns: new[] { "staff_id", "address", "code", "created_at", "dob", "department_id", "email", "firstname", "gender", "hired_date", "is_active", "is_deleted", "lastname", "phonenumber", "position", "salary", "updated_at" },
                values: new object[,]
                {
                    { "369984ef-0787-42d1-b35a-0e863eca3e8e", "202 Secret Rd", "S006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2004-01-01 00:00:00", "38caf774-3b85-4d0d-8a08-ba7e14b8687e", "tola.seyha@hms.com", "Seyha", 0, new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Tola", "1111-1111", "Administrator", 0m, null },
                    { "5a4748d9-6152-4844-9ba5-0001758e9032", "202 Secret Rd", "S005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1995-02-28 00:00:00", "2a5d58b7-8fb8-4ad0-aa8c-6ad25d8d8cbb", "eve.adams@hms.com", "Eve", 1, new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Adams", "555-5555", "Receptionist", 0m, null },
                    { "648c2a64-16fc-400e-a974-f14b8e6a44fd", "123 Main St", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1980-05-15 00:00:00", "1642e3af-542f-46f0-9bcc-c1f1b7550386", "alice.smith@hms.com", "Alice", 1, new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Smith", "555-1111", "Doctor", 0m, null },
                    { "6fdf662c-750e-4e01-af44-5524151e6022", "456 Oak Ave", "S002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1975-08-20 00:00:00", "91c6b605-97c1-4657-971c-e2e47c02a517", "bob.johnson@hms.com", "Bob", 0, new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Johnson", "555-2222", "Nurse", 0m, null },
                    { "89454f47-a9c4-43a5-a28e-93f85e8ec5b4", "101 Hero Way", "S004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1982-11-03 00:00:00", "1077b6fa-06fa-4974-b36e-a75638ba6ea4", "diana.prince@hms.com", "Diana", 1, new DateTime(2012, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Prince", "555-4444", "Technician", 0m, null },
                    { "cabb4ffb-aeaa-453e-9742-12bb0a00c693", "789 Pine Ln", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-01-25 00:00:00", "dedf8e44-dce2-482b-8b88-ec68b384a14e", "charlie.brown@hms.com", "Charlie", 0, new DateTime(2015, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Brown", "555-3333", "Doctor", 0m, null }
                });

            migrationBuilder.InsertData(
                table: "tbl_doctors",
                columns: new[] { "doctor_id", "code", "created_at", "is_active", "is_deleted", "license_number", "specialization", "staff_id", "stopped_work", "updated_at", "years_of_experience " },
                values: new object[,]
                {
                    { "a9b3dcc7-09bd-43a0-ab07-9d88b8337cda", "S001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-CARD-001", "Cardiology", "648c2a64-16fc-400e-a974-f14b8e6a44fd", false, null, 15 },
                    { "ca00c556-1ac1-4a2f-a894-2b1e766a090a", "S003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "LIC-PED-001", "Pediatrics", "cabb4ffb-aeaa-453e-9742-12bb0a00c693", false, null, 10 }
                });

            migrationBuilder.InsertData(
                table: "tbl_users",
                columns: new[] { "user_id", "code", "created_at", "is_active", "is_deleted", "password", "staff_id", "updated_at", "username" },
                values: new object[] { "375dba64-2bfb-4ef8-bf42-de39e9060936", "U001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "123456", "369984ef-0787-42d1-b35a-0e863eca3e8e", null, "Seyha" });

            migrationBuilder.InsertData(
                table: "tbl_patients",
                columns: new[] { "patient_id", "address", "code", "created_at", "dob", "doctor_id", "email", "firstname", "gender", "is_active", "is_deleted", "lastname", "phonenumber", "sickness", "updated_at" },
                values: new object[,]
                {
                    { "11e49000-bd3f-4e65-ac10-a7efc086f591", "303 River St", "P001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1960-03-10 00:00:00", "a9b3dcc7-09bd-43a0-ab07-9d88b8337cda", "frank.white@example.com", "Frank", 0, true, false, "White", "555-6666", "Headache", null },
                    { "36e3ed7d-9235-4d1c-be78-6bf39f7c5972", "505 Mountain View", "P003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1990-12-25 00:00:00", "a9b3dcc7-09bd-43a0-ab07-9d88b8337cda", "henry.green@example.com", "Henry", 0, true, false, "Green", "555-8888", "Cold", null },
                    { "bc824852-428b-4f0a-a398-f27cd259dbcf", "404 Lake Rd", "P002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2018-07-01 00:00:00", "ca00c556-1ac1-4a2f-a894-2b1e766a090a", "grace.black@example.com", "Grace", 1, true, false, "Black", "555-7777", "Fatigue", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors",
                column: "license_number",
                unique: true,
                filter: "[is_deleted] = 0 AND [license_number] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_departments_code",
                table: "tbl_departments",
                column: "code",
                unique: true,
                filter: "[is_deleted] = 0 AND [code] <> ''");

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
                name: "tbl_users");

            migrationBuilder.DropIndex(
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors");

            migrationBuilder.DropIndex(
                name: "IX_tbl_departments_code",
                table: "tbl_departments");

            migrationBuilder.DeleteData(
                table: "tbl_patients",
                keyColumn: "patient_id",
                keyValue: "11e49000-bd3f-4e65-ac10-a7efc086f591");

            migrationBuilder.DeleteData(
                table: "tbl_patients",
                keyColumn: "patient_id",
                keyValue: "36e3ed7d-9235-4d1c-be78-6bf39f7c5972");

            migrationBuilder.DeleteData(
                table: "tbl_patients",
                keyColumn: "patient_id",
                keyValue: "bc824852-428b-4f0a-a398-f27cd259dbcf");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "369984ef-0787-42d1-b35a-0e863eca3e8e");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "5a4748d9-6152-4844-9ba5-0001758e9032");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "6fdf662c-750e-4e01-af44-5524151e6022");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "89454f47-a9c4-43a5-a28e-93f85e8ec5b4");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "1077b6fa-06fa-4974-b36e-a75638ba6ea4");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "2a5d58b7-8fb8-4ad0-aa8c-6ad25d8d8cbb");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "38caf774-3b85-4d0d-8a08-ba7e14b8687e");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "91c6b605-97c1-4657-971c-e2e47c02a517");

            migrationBuilder.DeleteData(
                table: "tbl_doctors",
                keyColumn: "doctor_id",
                keyValue: "a9b3dcc7-09bd-43a0-ab07-9d88b8337cda");

            migrationBuilder.DeleteData(
                table: "tbl_doctors",
                keyColumn: "doctor_id",
                keyValue: "ca00c556-1ac1-4a2f-a894-2b1e766a090a");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "648c2a64-16fc-400e-a974-f14b8e6a44fd");

            migrationBuilder.DeleteData(
                table: "tbl_staffs",
                keyColumn: "staff_id",
                keyValue: "cabb4ffb-aeaa-453e-9742-12bb0a00c693");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "1642e3af-542f-46f0-9bcc-c1f1b7550386");

            migrationBuilder.DeleteData(
                table: "tbl_departments",
                keyColumn: "department_id",
                keyValue: "dedf8e44-dce2-482b-8b88-ec68b384a14e");

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
                name: "IX_tbl_doctors_license_number",
                table: "tbl_doctors",
                column: "license_number",
                unique: true,
                filter: "[is_deleted] = 0");
        }
    }
}
