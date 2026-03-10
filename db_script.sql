IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [tbl_departments] (
    [department_id] varchar(150) NOT NULL,
    [name] varchar(255) COLLATE SQL_Latin1_General_CP850_BIN NOT NULL,
    [description] varchar(500) NULL,
    [code] varchar(150) NOT NULL,
    [is_active] bit NOT NULL,
    [is_deleted] bit NOT NULL,
    [created_at] datetime2 NOT NULL,
    [updated_at] datetime2 NULL,
    CONSTRAINT [PK_tbl_departments] PRIMARY KEY ([department_id])
);
GO

CREATE TABLE [tbl_staffs] (
    [staff_id] varchar(150) NOT NULL,
    [position] varchar(150) NOT NULL,
    [hired_date] datetime2 NOT NULL,
    [salary] decimal(18,2) NOT NULL,
    [department_id] varchar(150) NOT NULL,
    [code] varchar(150) NOT NULL,
    [is_active] bit NOT NULL,
    [is_deleted] bit NOT NULL,
    [created_at] datetime2 NOT NULL,
    [updated_at] datetime2 NULL,
    [firstname] varchar(70) COLLATE SQL_Latin1_General_CP850_BIN NOT NULL,
    [lastname] varchar(70) COLLATE SQL_Latin1_General_CP850_BIN NOT NULL,
    [dob] varchar(150) NOT NULL,
    [gender] integer NOT NULL,
    [phonenumber] varchar(20) NULL,
    [address] varchar(50) NULL,
    [email] varchar(150) NULL,
    CONSTRAINT [PK_tbl_staffs] PRIMARY KEY ([staff_id]),
    CONSTRAINT [CHK_CODE_NOT_EMPTY1] CHECK (LTRIM(RTRIM(ISNULL([Code], ''))) <> ''),
    CONSTRAINT [CHK_NAME_NOT_EMPTY1] CHECK (LTRIM(RTRIM(FirstName + ' ' + LastName)) <> ''),
    CONSTRAINT [FK_tbl_staffs_tbl_departments_department_id] FOREIGN KEY ([department_id]) REFERENCES [tbl_departments] ([department_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_doctors] (
    [doctor_id] varchar(150) NOT NULL,
    [specialization] varchar(150) NOT NULL,
    [license_number] varchar(150) NOT NULL,
    [years_of_experience ] integer NOT NULL,
    [stopped_work] bit NOT NULL,
    [staff_id] varchar(150) NOT NULL,
    [code] varchar(150) NOT NULL,
    [is_active] bit NOT NULL,
    [is_deleted] bit NOT NULL,
    [created_at] datetime2 NOT NULL,
    [updated_at] datetime2 NULL,
    CONSTRAINT [PK_tbl_doctors] PRIMARY KEY ([doctor_id]),
    CONSTRAINT [FK_tbl_doctors_tbl_staffs_staff_id] FOREIGN KEY ([staff_id]) REFERENCES [tbl_staffs] ([staff_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_users] (
    [user_id] varchar(150) NOT NULL,
    [username] varchar(150) NOT NULL,
    [password] varchar(255) NOT NULL,
    [staff_id] varchar(150) NOT NULL,
    [code] varchar(150) NOT NULL,
    [is_active] bit NOT NULL,
    [is_deleted] bit NOT NULL,
    [created_at] datetime2 NOT NULL,
    [updated_at] datetime2 NULL,
    CONSTRAINT [PK_tbl_users] PRIMARY KEY ([user_id]),
    CONSTRAINT [CHK_CODE_NOT_EMPTY2] CHECK (LTRIM(RTRIM(ISNULL([Code], ''))) <> ''),
    CONSTRAINT [CHK_NAME_NOT_EMPTY2] CHECK (LTRIM(RTRIM(Username)) <> ''),
    CONSTRAINT [FK_tbl_users_tbl_staffs_staff_id] FOREIGN KEY ([staff_id]) REFERENCES [tbl_staffs] ([staff_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [tbl_patients] (
    [patient_id] varchar(150) NOT NULL,
    [sickness] varchar(150) NOT NULL,
    [doctor_id] varchar(150) NOT NULL,
    [code] varchar(150) NOT NULL,
    [is_active] bit NOT NULL,
    [is_deleted] bit NOT NULL,
    [created_at] datetime2 NOT NULL,
    [updated_at] datetime2 NULL,
    [firstname] varchar(70) COLLATE SQL_Latin1_General_CP850_BIN NOT NULL,
    [lastname] varchar(70) COLLATE SQL_Latin1_General_CP850_BIN NOT NULL,
    [dob] varchar(150) NOT NULL,
    [gender] integer NOT NULL,
    [phonenumber] varchar(20) NULL,
    [address] varchar(50) NULL,
    [email] varchar(150) NULL,
    CONSTRAINT [PK_tbl_patients] PRIMARY KEY ([patient_id]),
    CONSTRAINT [CHK_CODE_NOT_EMPTY] CHECK (LTRIM(RTRIM(ISNULL([Code], ''))) <> ''),
    CONSTRAINT [CHK_NAME_NOT_EMPTY] CHECK (LTRIM(RTRIM(FirstName + ' ' + LastName)) <> ''),
    CONSTRAINT [FK_tbl_patients_tbl_doctors_doctor_id] FOREIGN KEY ([doctor_id]) REFERENCES [tbl_doctors] ([doctor_id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'department_id', N'code', N'created_at', N'description', N'is_active', N'is_deleted', N'name', N'updated_at') AND [object_id] = OBJECT_ID(N'[tbl_departments]'))
    SET IDENTITY_INSERT [tbl_departments] ON;
INSERT INTO [tbl_departments] ([department_id], [code], [created_at], [description], [is_active], [is_deleted], [name], [updated_at])
VALUES ('2883fe52-f4ca-4ce2-9999-6c0280668b2f', 'ORTH', '0001-01-01T00:00:00.0000000', 'Bone and Joint Department', CAST(1 AS bit), CAST(0 AS bit), 'Orthopedics', NULL),
('4aa491b1-97cb-4189-8e03-d4ea8c27af6d', 'CAD', '0001-01-01T00:00:00.0000000', 'Heart and Cardiovascular Department', CAST(1 AS bit), CAST(0 AS bit), 'Cardiology', NULL),
('4e795955-b97a-4f02-b6bd-334df9f79e47', 'GM', '0001-01-01T00:00:00.0000000', 'General Health Department', CAST(1 AS bit), CAST(0 AS bit), 'General Medicine', NULL),
('63347532-a564-4e23-a5d9-c7de4ef82da0', 'IT', '0001-01-01T00:00:00.0000000', 'Information Technology', CAST(1 AS bit), CAST(0 AS bit), 'IT', NULL),
('80655e05-0aa7-4feb-860e-32ac14a19864', 'PED', '0001-01-01T00:00:00.0000000', 'Children Health Department', CAST(1 AS bit), CAST(0 AS bit), 'Pediatrics', NULL),
('d3200872-4f52-4982-b1a4-0ed85ee3f927', 'EMG', '0001-01-01T00:00:00.0000000', 'Emergency Department', CAST(1 AS bit), CAST(0 AS bit), 'Emergency', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'department_id', N'code', N'created_at', N'description', N'is_active', N'is_deleted', N'name', N'updated_at') AND [object_id] = OBJECT_ID(N'[tbl_departments]'))
    SET IDENTITY_INSERT [tbl_departments] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'staff_id', N'address', N'code', N'created_at', N'dob', N'department_id', N'email', N'firstname', N'gender', N'hired_date', N'is_active', N'is_deleted', N'lastname', N'phonenumber', N'position', N'salary', N'updated_at') AND [object_id] = OBJECT_ID(N'[tbl_staffs]'))
    SET IDENTITY_INSERT [tbl_staffs] ON;
INSERT INTO [tbl_staffs] ([staff_id], [address], [code], [created_at], [dob], [department_id], [email], [firstname], [gender], [hired_date], [is_active], [is_deleted], [lastname], [phonenumber], [position], [salary], [updated_at])
VALUES ('2db25790-c22a-4adb-8f3b-8e3a7b94d851', '456 Oak Ave', 'S002', '0001-01-01T00:00:00.0000000', '1975-08-20 00:00:00', '4e795955-b97a-4f02-b6bd-334df9f79e47', 'bob.johnson@hms.com', 'Bob', 0, '2005-03-10T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Johnson', '555-2222', 'Nurse', 0.0, NULL),
('83f71025-693f-4067-9b85-84232d4bdce6', '202 Secret Rd', 'S006', '0001-01-01T00:00:00.0000000', '2004-01-01 00:00:00', '63347532-a564-4e23-a5d9-c7de4ef82da0', 'tola.seyha@hms.com', 'Seyha', 0, '2022-04-20T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Tola', '1111-1111', 'Administrator', 0.0, NULL),
('92c7323b-d3c2-4024-826c-2a6d4f357c1c', '101 Hero Way', 'S004', '0001-01-01T00:00:00.0000000', '1982-11-03 00:00:00', '2883fe52-f4ca-4ce2-9999-6c0280668b2f', 'diana.prince@hms.com', 'Diana', 1, '2012-09-15T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Prince', '555-4444', 'Technician', 0.0, NULL),
('991d5722-d08f-4206-b782-80067da7c4b2', '123 Main St', 'S001', '0001-01-01T00:00:00.0000000', '1980-05-15 00:00:00', '4aa491b1-97cb-4189-8e03-d4ea8c27af6d', 'alice.smith@hms.com', 'Alice', 1, '2010-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Smith', '555-1111', 'Doctor', 0.0, NULL),
('bd1a58da-9479-4f52-802e-90e774249411', '202 Secret Rd', 'S005', '0001-01-01T00:00:00.0000000', '1995-02-28 00:00:00', 'd3200872-4f52-4982-b1a4-0ed85ee3f927', 'eve.adams@hms.com', 'Eve', 1, '2018-04-20T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Adams', '555-5555', 'Receptionist', 0.0, NULL),
('cb842b1f-e86c-46f0-9176-c7cf53f32d1a', '789 Pine Ln', 'S003', '0001-01-01T00:00:00.0000000', '1990-01-25 00:00:00', '80655e05-0aa7-4feb-860e-32ac14a19864', 'charlie.brown@hms.com', 'Charlie', 0, '2015-07-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Brown', '555-3333', 'Doctor', 0.0, NULL),
('f80785eb-4de2-4dd6-9467-f3f0df47a952', '202 Secret Rd', 'S007', '0001-01-01T00:00:00.0000000', '2005-01-01 00:00:00', '63347532-a564-4e23-a5d9-c7de4ef82da0', 'tor.soklumor@hms.com', 'Soklumor', 0, '2022-04-20T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'Tor', '2222-2222', 'IT', 0.0, NULL),
('da6a4964-6725-4c01-a481-99527f311f92', 'Hospital', 'S000', '0001-01-01T00:00:00.0000000', '1990-01-01 00:00:00', '63347532-a564-4e23-a5d9-c7de4ef82da0', 'admin@hms.com', 'Admin', 0, '2020-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'User', '000-0000', 'Administrator', 0.0, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'staff_id', N'address', N'code', N'created_at', N'dob', N'department_id', N'email', N'firstname', N'gender', N'hired_date', N'is_active', N'is_deleted', N'lastname', N'phonenumber', N'position', N'salary', N'updated_at') AND [object_id] = OBJECT_ID(N'[tbl_staffs]'))
    SET IDENTITY_INSERT [tbl_staffs] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'doctor_id', N'code', N'created_at', N'is_active', N'is_deleted', N'license_number', N'specialization', N'staff_id', N'stopped_work', N'updated_at', N'years_of_experience ') AND [object_id] = OBJECT_ID(N'[tbl_doctors]'))
    SET IDENTITY_INSERT [tbl_doctors] ON;
INSERT INTO [tbl_doctors] ([doctor_id], [code], [created_at], [is_active], [is_deleted], [license_number], [specialization], [staff_id], [stopped_work], [updated_at], [years_of_experience ])
VALUES ('7f760449-40eb-4483-8a34-095bc94c4b46', 'S003', '0001-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'LIC-PED-001', 'Pediatrics', 'cb842b1f-e86c-46f0-9176-c7cf53f32d1a', CAST(0 AS bit), NULL, 10),
('f23d761d-82be-42e1-8bc8-19392ed61b62', 'S001', '0001-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'LIC-CARD-001', 'Cardiology', '991d5722-d08f-4206-b782-80067da7c4b2', CAST(0 AS bit), NULL, 15);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'doctor_id', N'code', N'created_at', N'is_active', N'is_deleted', N'license_number', N'specialization', N'staff_id', N'stopped_work', N'updated_at', N'years_of_experience ') AND [object_id] = OBJECT_ID(N'[tbl_doctors]'))
    SET IDENTITY_INSERT [tbl_doctors] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'user_id', N'code', N'created_at', N'is_active', N'is_deleted', N'password', N'staff_id', N'updated_at', N'username') AND [object_id] = OBJECT_ID(N'[tbl_users]'))
    SET IDENTITY_INSERT [tbl_users] ON;
INSERT INTO [tbl_users] ([user_id], [code], [created_at], [is_active], [is_deleted], [password], [staff_id], [updated_at], [username])
VALUES ('00ea1daf-21ce-49c7-a12e-1b3e31b2257c', 'S007', '0001-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'admin', 'f80785eb-4de2-4dd6-9467-f3f0df47a952', NULL, 'Lumor'),
('b2d43c94-c5d0-4d9c-b05f-d27c25a6aaba', 'S006', '0001-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), '123456', '83f71025-693f-4067-9b85-84232d4bdce6', NULL, 'Seyha'),
('b78a9c2e-2e4d-4e9a-9e2a-1c5d6e7f8a9b', 'S000', '0001-01-01T00:00:00.0000000', CAST(1 AS bit), CAST(0 AS bit), 'admin', 'da6a4964-6725-4c01-a481-99527f311f92', NULL, 'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'user_id', N'code', N'created_at', N'is_active', N'is_deleted', N'password', N'staff_id', N'updated_at', N'username') AND [object_id] = OBJECT_ID(N'[tbl_users]'))
    SET IDENTITY_INSERT [tbl_users] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'patient_id', N'address', N'code', N'created_at', N'dob', N'doctor_id', N'email', N'firstname', N'gender', N'is_active', N'is_deleted', N'lastname', N'phonenumber', N'sickness', N'updated_at') AND [object_id] = OBJECT_ID(N'[tbl_patients]'))
    SET IDENTITY_INSERT [tbl_patients] ON;
INSERT INTO [tbl_patients] ([patient_id], [address], [code], [created_at], [dob], [doctor_id], [email], [firstname], [gender], [is_active], [is_deleted], [lastname], [phonenumber], [sickness], [updated_at])
VALUES ('23da1e1f-96fd-446e-9568-473762b2049d', '303 River St', 'P001', '0001-01-01T00:00:00.0000000', '1960-03-10 00:00:00', 'f23d761d-82be-42e1-8bc8-19392ed61b62', 'frank.white@example.com', 'Frank', 0, CAST(1 AS bit), CAST(0 AS bit), 'White', '555-6666', 'Headache', NULL),
('847ba0b5-b4c8-4666-9063-c047f89ed82b', '404 Lake Rd', 'P002', '0001-01-01T00:00:00.0000000', '2018-07-01 00:00:00', '7f760449-40eb-4483-8a34-095bc94c4b46', 'grace.black@example.com', 'Grace', 1, CAST(1 AS bit), CAST(0 AS bit), 'Black', '555-7777', 'Fatigue', NULL),
('d2235564-74c6-4879-a5d6-8e464b062cd3', '505 Mountain View', 'P003', '0001-01-01T00:00:00.0000000', '1990-12-25 00:00:00', 'f23d761d-82be-42e1-8bc8-19392ed61b62', 'henry.green@example.com', 'Henry', 0, CAST(1 AS bit), CAST(0 AS bit), 'Green', '555-8888', 'Cold', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'patient_id', N'address', N'code', N'created_at', N'dob', N'doctor_id', N'email', N'firstname', N'gender', N'is_active', N'is_deleted', N'lastname', N'phonenumber', N'sickness', N'updated_at') AND [object_id] = OBJECT_ID(N'[tbl_patients]'))
    SET IDENTITY_INSERT [tbl_patients] OFF;
GO

CREATE UNIQUE INDEX [IX_tbl_departments_code] ON [tbl_departments] ([code]) WHERE [is_deleted] = 0 AND [code] <> '';
GO

CREATE UNIQUE INDEX [IX_tbl_departments_name] ON [tbl_departments] ([name]) WHERE [is_deleted] = 0 AND [name] <> '';
GO

CREATE UNIQUE INDEX [IX_tbl_doctors_license_number] ON [tbl_doctors] ([license_number]) WHERE [is_deleted] = 0 AND [license_number] <> '';
GO

CREATE INDEX [IX_tbl_doctors_specialization] ON [tbl_doctors] ([specialization]);
GO

CREATE UNIQUE INDEX [IX_tbl_doctors_staff_id] ON [tbl_doctors] ([staff_id]) WHERE [is_deleted] = 0;
GO

CREATE UNIQUE INDEX [IX_tbl_patients_code] ON [tbl_patients] ([code]) WHERE [is_deleted] = 0;
GO

CREATE INDEX [IX_tbl_patients_doctor_id] ON [tbl_patients] ([doctor_id]);
GO

CREATE INDEX [IX_tbl_patients_firstname_lastname] ON [tbl_patients] ([firstname], [lastname]);
GO

CREATE UNIQUE INDEX [IX_tbl_staffs_code] ON [tbl_staffs] ([code]) WHERE [is_deleted] = 0;
GO

CREATE INDEX [IX_tbl_staffs_department_id] ON [tbl_staffs] ([department_id]);
GO

CREATE UNIQUE INDEX [IX_tbl_users_code] ON [tbl_users] ([code]) WHERE [is_deleted] = 0;
GO

CREATE UNIQUE INDEX [IX_tbl_users_staff_id] ON [tbl_users] ([staff_id]) WHERE [is_deleted] = 0;
GO

CREATE UNIQUE INDEX [IX_tbl_users_username] ON [tbl_users] ([username]) WHERE [is_deleted] = 0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251113100559_InitializeDB', N'8.0.21');
GO

COMMIT;
GO

