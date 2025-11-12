using Hospital_management_system.Domain.Entities;
using Hospital_management_system.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<User> Users { get; set; }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified &&
                    (e.Entity is Department || e.Entity is Staff ||
                     e.Entity is Patient || e.Entity is Doctor));
            foreach (var entry in entries)
            {
                if (entry.Entity is Department dept)
                    dept.UpdatedAt = DateTime.UtcNow.AddHours(7);
                else if (entry.Entity is Staff staff)
                    staff.UpdatedAt = DateTime.UtcNow.AddHours(7);
                else if (entry.Entity is Doctor doctor)
                    doctor.UpdatedAt = DateTime.UtcNow.AddHours(7);
                else if (entry.Entity is Patient patient)
                    patient.UpdatedAt = DateTime.UtcNow.AddHours(7);
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception($"Database save error: {ex.Message}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Automatically apply soft delete filters
        //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //{
        //    if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
        //    {
        //        var parameter = Expression.Parameter(entityType.ClrType, "e");
        //        var prop = Expression.Property(parameter, "IsDeleted");
        //        var condition = Expression.Equal(prop, Expression.Constant(false));
        //        var lambda = Expression.Lambda(condition, parameter);

        //        modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        //    }
        //}

        #region Departments
        modelBuilder.Entity<Department>(buildAction =>
        {
            buildAction
                .Property(d => d.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(d => d.Code)
                .IsUnique()
                .HasFilter("[is_deleted] = 0 AND [code] <> ''");
            buildAction
                .HasIndex(d => d.Name)
                .IsUnique()
                .HasFilter("[is_deleted] = 0 AND [name] <> ''");

        });
        #endregion
        
        #region Doctor
        modelBuilder.Entity<Doctor>(buildAction =>
        {
            buildAction
                .HasIndex(d => d.LicenseNumber)
                .IsUnique()
                .HasFilter("[is_deleted] = 0 AND [license_number] <> ''");
            buildAction
                .HasIndex(d => d.StaffId)
                .IsUnique()
                .HasFilter("[is_deleted] = 0");
            buildAction.HasIndex(d => d.Specialization);

            buildAction
                .HasOne(d => d.Staff)
                .WithOne(s => s.Doctor)
                .HasForeignKey<Doctor>(d => d.StaffId);
        });
        #endregion
        
        #region Staffs
        modelBuilder.Entity<Staff>(buildAction =>
        {
            buildAction
                .Property(s => s.FirstName)
                .HasColumnName("firstname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction
                .Property(s => s.LastName)
                .HasColumnName("lastname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(s => s.Code).IsUnique().HasFilter("[is_deleted] = 0");

            buildAction.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CHK_CODE_NOT_EMPTY",
                    $"LTRIM(RTRIM(ISNULL([{nameof(Staff.Code)}], ''))) <> ''"
                );
                t.HasCheckConstraint(
                    "CHK_NAME_NOT_EMPTY",
                    $"LTRIM(RTRIM({nameof(Staff.FirstName)} + ' ' + {nameof(Staff.LastName)})) <> ''"
                );
            });

            buildAction
                .HasOne(s => s.Department)
                .WithMany(d => d.Staffs)
                .HasForeignKey(s => s.DepartmentId);
        });
        #endregion

        #region Patients
        modelBuilder.Entity<Patient>(buildAction =>
        {
            buildAction
                .Property(p => p.FirstName)
                .HasColumnName("firstname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction
                .Property(p => p.LastName)
                .HasColumnName("lastname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(p => p.Code).IsUnique().HasFilter("[is_deleted] = 0");
            buildAction.HasIndex(p => new { p.FirstName, p.LastName });
            buildAction
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Patients)
                .HasForeignKey(a => a.DoctorId);

            buildAction.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CHK_CODE_NOT_EMPTY",
                    $"LTRIM(RTRIM(ISNULL([{nameof(Patient.Code)}], ''))) <> ''"
                );
                t.HasCheckConstraint(
                    "CHK_NAME_NOT_EMPTY",
                    $"LTRIM(RTRIM({nameof(Patient.FirstName)} + ' ' + {nameof(Patient.LastName)})) <> ''"
                );
            });
        });
        #endregion

        modelBuilder.Entity<User>(buildAction =>
        {
            buildAction.HasIndex(u => u.Code).IsUnique().HasFilter("[is_deleted] = 0");
            buildAction.HasIndex(u => u.StaffId).IsUnique().HasFilter("[is_deleted] = 0");
            buildAction
                .HasOne(u => u.Staff)
                .WithOne(s => s.User)
                .HasForeignKey<User>(s => s.StaffId);

            buildAction.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CHK_CODE_NOT_EMPTY",
                    $"LTRIM(RTRIM(ISNULL([{nameof(User.Code)}], ''))) <> ''"
                );
                t.HasCheckConstraint(
                    "CHK_NAME_NOT_EMPTY",
                    $"LTRIM(RTRIM({nameof(User.Username)})) <> ''"
                );
            });
        });
            

        #region Seed data
        var cardiologyDepartmentId = Guid.NewGuid().ToString();
        var pediatricsDepartmentId = Guid.NewGuid().ToString();
        var orthopedicsDepartmentId = Guid.NewGuid().ToString();
        var generalMedicineDepartmentId = Guid.NewGuid().ToString();
        var emergencyDepartmentId = Guid.NewGuid().ToString();

        modelBuilder.Entity<Department>().HasData(
           new Department { Code = "CAD", DepartmentId = cardiologyDepartmentId, Name = "Cardiology", Description = "Heart and Cardiovascular Department" },
           new Department { Code = "PED", DepartmentId = pediatricsDepartmentId, Name = "Pediatrics", Description = "Children Health Department" },
           new Department { Code = "ORTH", DepartmentId = orthopedicsDepartmentId, Name = "Orthopedics", Description = "Bone and Joint Department" },
           new Department { Code = "GM", DepartmentId = generalMedicineDepartmentId, Name = "General Medicine", Description = "General Health Department" },
           new Department { Code = "EMG", DepartmentId = emergencyDepartmentId, Name = "Emergency", Description = "Emergency Department" }
        );

        var staff1Id = Guid.NewGuid().ToString();
        var staff2Id = Guid.NewGuid().ToString();
        var staff3Id = Guid.NewGuid().ToString();
        var staff4Id = Guid.NewGuid().ToString();
        var staff5Id = Guid.NewGuid().ToString();

        modelBuilder.Entity<Staff>().HasData(
            new Staff
            {
                StaffId = staff1Id,
                Code = "S001",
                FirstName = "Alice",
                LastName = "Smith",
                DOB = new DateTime(1980, 5, 15),
                Gender = PersonGender.Female,
                Address = "123 Main St",
                PhoneNumber = "555-1111",
                Email = "alice.smith@hms.com",
                Position = Position.Doctor.ToString(),
                DepartmentId = cardiologyDepartmentId,
                HiredDate = new DateTime(2010, 1, 1)
            },
            new Staff
            {
                StaffId = staff2Id,
                Code = "S002",
                FirstName = "Bob",
                LastName = "Johnson",
                DOB = new DateTime(1975, 8, 20),
                Gender = PersonGender.Male,
                Address = "456 Oak Ave",
                PhoneNumber = "555-2222",
                Email = "bob.johnson@hms.com",
                Position = Position.Administrator.ToString(),
                DepartmentId = generalMedicineDepartmentId,
                HiredDate = new DateTime(2005, 3, 10)
            },
            new Staff
            {
                StaffId = staff3Id,
                Code = "S003",
                FirstName = "Charlie",
                LastName = "Brown",
                DOB = new DateTime(1990, 1, 25),
                Gender = PersonGender.Male,
                Address = "789 Pine Ln",
                PhoneNumber = "555-3333",
                Email = "charlie.brown@hms.com",
                Position = Position.Doctor.ToString(),
                DepartmentId = pediatricsDepartmentId,
                HiredDate = new DateTime(2015, 7, 1)
            },
            new Staff
            {
                StaffId = staff4Id,
                Code = "S004",
                FirstName = "Diana",
                LastName = "Prince",
                DOB = new DateTime(1982, 11, 3),
                Gender = PersonGender.Female,
                Address = "101 Hero Way",
                PhoneNumber = "555-4444",
                Email = "diana.prince@hms.com",
                Position = Position.Technician.ToString(),
                DepartmentId = orthopedicsDepartmentId,
                HiredDate = new DateTime(2012, 9, 15)
            },
            new Staff
            {
                StaffId = staff5Id,
                Code = "S005",
                FirstName = "Eve",
                LastName = "Adams",
                DOB = new DateTime(1995, 2, 28),
                Gender = PersonGender.Female,
                Address = "202 Secret Rd",
                PhoneNumber = "555-5555",
                Email = "eve.adams@hms.com",
                Position = Position.Receptionist.ToString(),
                DepartmentId = emergencyDepartmentId,
                HiredDate = new DateTime(2018, 4, 20)
            }
        );

        var doctor1Id = Guid.NewGuid().ToString();
        var doctor2Id = Guid.NewGuid().ToString();

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                DoctorId = doctor1Id,
                Code = "S001",
                StaffId = staff1Id,
                LicenseNumber = "LIC-CARD-001",
                Specialization = Specialization.Cardiology.ToString(),
                YearsOfExperience = 15
            },
            new Doctor
            {
                DoctorId = doctor2Id,
                Code = "S003",
                StaffId = staff3Id,
                LicenseNumber = "LIC-PED-001",
                Specialization = Specialization.Pediatrics.ToString(),
                YearsOfExperience = 10
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                PatientId = Guid.NewGuid().ToString(),
                Code = "P001",
                FirstName = "Frank",
                LastName = "White",
                DOB = new DateTime(1960, 3, 10),
                Gender = PersonGender.Male,
                Address = "303 River St",
                PhoneNumber = "555-6666",
                Email = "frank.white@example.com",
                Sickness = "Headache",
                DoctorId = doctor1Id,
            },
            new Patient
            {
                PatientId = Guid.NewGuid().ToString(),
                Code = "P002",
                FirstName = "Grace",
                LastName = "Black",
                DOB = new DateTime(2018, 7, 1),
                Gender = PersonGender.Female,
                Address = "404 Lake Rd",
                PhoneNumber = "555-7777",
                Email = "grace.black@example.com",
                Sickness = "Fatigue",
                DoctorId = doctor2Id,
            },
            new Patient
            {
                PatientId = Guid.NewGuid().ToString(),
                Code = "P003",
                FirstName = "Henry",
                LastName = "Green",
                DOB = new DateTime(1990, 12, 25),
                Gender = PersonGender.Male,
                Address = "505 Mountain View",
                PhoneNumber = "555-8888",
                Email = "henry.green@example.com",
                Sickness = "Cold",
                DoctorId = doctor1Id,
            }
        );
        #endregion
        //base.OnModelCreating(modelBuilder);
    }
}