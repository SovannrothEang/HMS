CREATE DATABASE hms;
GO

USE hms;
GO

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

CREATE TABLE [tbl_positions] (
    [position_id] varchar(150) NOT NULL,
    [name] varchar(255) NOT NULL,
    [description] varchar(500) NULL,
    [department_id] varchar(150) NOT NULL,
    [code] varchar(150) NOT NULL,
    [is_active] bit NOT NULL,
    [is_deleted] bit NOT NULL,
    [created_at] datetime2 NOT NULL,
    [updated_at] datetime2 NULL,
    CONSTRAINT [PK_tbl_positions] PRIMARY KEY ([position_id]),
    CONSTRAINT [FK_tbl_positions_tbl_departments_department_id] FOREIGN KEY ([department_id]) REFERENCES [tbl_departments] ([department_id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_tbl_positions_code] ON [tbl_positions] ([code]) WHERE [is_deleted] = 0;
GO

CREATE TABLE [tbl_staffs] (
    [staff_id] varchar(150) NOT NULL,
    [position_id] varchar(150) NOT NULL,
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
    CONSTRAINT [FK_tbl_staffs_tbl_departments_department_id] FOREIGN KEY ([department_id]) REFERENCES [tbl_departments] ([department_id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_tbl_staffs_tbl_positions_position_id] FOREIGN KEY ([position_id]) REFERENCES [tbl_positions] ([position_id]) ON DELETE NO ACTION
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

-- Seeding
INSERT INTO [tbl_departments] ([department_id], [code], [created_at], [description], [is_active], [is_deleted], [name], [updated_at])
VALUES 
('dept-001', 'ORTH', GETDATE(), 'Bone and Joint Department', 1, 0, 'Orthopedics', NULL),
('dept-002', 'CAD', GETDATE(), 'Heart and Cardiovascular Department', 1, 0, 'Cardiology', NULL),
('dept-003', 'GM', GETDATE(), 'General Health Department', 1, 0, 'General Medicine', NULL),
('dept-004', 'IT', GETDATE(), 'Information Technology', 1, 0, 'IT', NULL),
('dept-005', 'PED', GETDATE(), 'Children Health Department', 1, 0, 'Pediatrics', NULL),
('dept-006', 'EMG', GETDATE(), 'Emergency Department', 1, 0, 'Emergency', NULL);
GO

INSERT INTO [tbl_positions] ([position_id], [code], [name], [description], [department_id], [is_active], [is_deleted], [created_at])
VALUES 
('pos-001', 'NUR', 'Nurse', 'Nursing staff', 'dept-003', 1, 0, GETDATE()),
('pos-002', 'DOC', 'Doctor', 'Medical doctor', 'dept-002', 1, 0, GETDATE()),
('pos-003', 'ADM', 'Administrator', 'Administrative staff', 'dept-004', 1, 0, GETDATE()),
('pos-004', 'TEC', 'Technician', 'Technical staff', 'dept-001', 1, 0, GETDATE()),
('pos-005', 'REC', 'Receptionist', 'Front desk staff', 'dept-006', 1, 0, GETDATE()),
('pos-006', 'ITS', 'IT Specialist', 'IT support staff', 'dept-004', 1, 0, GETDATE());
GO

INSERT INTO [tbl_staffs] ([staff_id], [address], [code], [created_at], [dob], [department_id], [email], [firstname], [gender], [hired_date], [is_active], [is_deleted], [lastname], [phonenumber], [position_id], [salary], [updated_at])
VALUES 
('staff-001', '456 Oak Ave', 'S002', GETDATE(), '1975-08-20', 'dept-003', 'bob.johnson@hms.com', 'Bob', 0, '2005-03-10', 1, 0, 'Johnson', '555-2222', 'pos-001', 0.0, NULL),
('staff-002', '202 Secret Rd', 'S006', GETDATE(), '2004-01-01', 'dept-004', 'tola.seyha@hms.com', 'Seyha', 0, '2022-04-20', 1, 0, 'Tola', '1111-1111', 'pos-003', 0.0, NULL),
('staff-003', '101 Hero Way', 'S004', GETDATE(), '1982-11-03', 'dept-001', 'diana.prince@hms.com', 'Diana', 1, '2012-09-15', 1, 0, 'Prince', '555-4444', 'pos-004', 0.0, NULL),
('staff-004', '123 Main St', 'S001', GETDATE(), '1980-05-15', 'dept-002', 'alice.smith@hms.com', 'Alice', 1, '2010-01-01', 1, 0, 'Smith', '555-1111', 'pos-002', 0.0, NULL),
('staff-005', '202 Secret Rd', 'S005', GETDATE(), '1995-02-28', 'dept-006', 'eve.adams@hms.com', 'Eve', 1, '2018-04-20', 1, 0, 'Adams', '555-5555', 'pos-005', 0.0, NULL),
('staff-006', '789 Pine Ln', 'S003', GETDATE(), '1990-01-25', 'dept-005', 'charlie.brown@hms.com', 'Charlie', 0, '2015-07-01', 1, 0, 'Brown', '555-3333', 'pos-002', 0.0, NULL),
('staff-007', '202 Secret Rd', 'S007', GETDATE(), '2005-01-01', 'dept-004', 'tor.soklumor@hms.com', 'Soklumor', 0, '2022-04-20', 1, 0, 'Tor', '2222-2222', 'pos-006', 0.0, NULL),
('staff-000', 'Hospital', 'S000', GETDATE(), '1990-01-01', 'dept-004', 'admin@hms.com', 'Admin', 0, '2020-01-01', 1, 0, 'User', '000-0000', 'pos-003', 0.0, NULL);
GO

INSERT INTO [tbl_doctors] ([doctor_id], [code], [created_at], [is_active], [is_deleted], [license_number], [specialization], [staff_id], [stopped_work], [updated_at], [years_of_experience ])
VALUES 
('doc-001', 'S003', GETDATE(), 1, 0, 'LIC-PED-001', 'Pediatrics', 'staff-006', 0, NULL, 10),
('doc-002', 'S001', GETDATE(), 1, 0, 'LIC-CARD-001', 'Cardiology', 'staff-004', 0, NULL, 15);
GO

INSERT INTO [tbl_users] ([user_id], [code], [created_at], [is_active], [is_deleted], [password], [staff_id], [updated_at], [username])
VALUES 
('user-001', 'S007', GETDATE(), 1, 0, 'admin', 'staff-007', NULL, 'Lumor'),
('user-002', 'S006', GETDATE(), 1, 0, '123456', 'staff-002', NULL, 'Seyha'),
('user-003', 'S000', GETDATE(), 1, 0, 'admin', 'staff-000', NULL, 'admin');
GO

INSERT INTO [tbl_patients] ([patient_id], [address], [code], [created_at], [dob], [doctor_id], [email], [firstname], [gender], [is_active], [is_deleted], [lastname], [phonenumber], [sickness], [updated_at])
VALUES 
('pat-001', '303 River St', 'P001', GETDATE(), '1960-03-10', 'doc-002', 'frank.white@example.com', 'Frank', 0, 1, 0, 'White', '555-6666', 'Headache', NULL),
('pat-002', '404 Lake Rd', 'P002', GETDATE(), '2018-07-01', 'doc-001', 'grace.black@example.com', 'Grace', 1, 1, 0, 'Black', '555-7777', 'Fatigue', NULL),
('pat-003', '505 Mountain View', 'P003', GETDATE(), '1990-12-25', 'doc-002', 'henry.green@example.com', 'Henry', 0, 1, 0, 'Green', '555-8888', 'Cold', NULL);
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
