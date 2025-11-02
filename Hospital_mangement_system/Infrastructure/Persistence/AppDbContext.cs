using Hospital_mangement_system.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital_mangement_system.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany()
            .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<Department>(buildAction =>
        {
            buildAction.Property(d => d.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(d => d.Name)
                .IsUnique()
                .HasFilter("name <> ''");

            
        });
        modelBuilder.Entity<Doctor>(buildAction =>
        {
            buildAction.Property(s => s.Firstname)
                .HasColumnName("firstname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.Property(s => s.Lastname)
                .HasColumnName("lastname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(d => d.Code).IsUnique();
            buildAction.HasIndex(d => d.LicenseNumber).IsUnique();
            buildAction.HasIndex(d => d.Specialization);
            buildAction.ToTable(t => {
                t.HasCheckConstraint(
                    "CHK_CODE_NOT_EMPTY",
                    $"LTRIM(RTRIM(ISNULL([{nameof(Doctor.Code)}], ''))) <> ''"
                );
                t.HasCheckConstraint(
                    "CHK_NAME_NOT_EMPTY",
                    $"LTRIM(RTRIM({nameof(Doctor.Firstname)} + ' ' + {nameof(Doctor.Lastname)})) <> ''"
                );
            });

            buildAction
                .HasOne(d => d.Staff)
                .WithOne(s => s.Doctor)
                .HasForeignKey<Doctor>(d => d.DoctorId);
        });
        modelBuilder.Entity<Staff>(buildAction =>
        {
            buildAction.Property(s => s.Firstname)
                .HasColumnName("firstname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.Property(s => s.Lastname)
                .HasColumnName("lastname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(s => s.Code).IsUnique();
            buildAction.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CHK_CODE_NOT_EMPTY",
                    $"LTRIM(RTRIM(ISNULL([{nameof(Staff.Code)}], ''))) <> ''"
                );
                t.HasCheckConstraint(
                    "CHK_NAME_NOT_EMPTY",
                    $"LTRIM(RTRIM({nameof(Staff.Firstname)} + ' ' + {nameof(Staff.Lastname)})) <> ''"
                );
            });

            buildAction
                .HasOne(s => s.Department)
                .WithMany(d => d.Staffs)
                .HasForeignKey(d => d.DepartmentId);
        });
        modelBuilder.Entity<Patient>(buildAction =>
        {
            buildAction.Property(p => p.Firstname)
                .HasColumnName("firstname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.Property(p => p.Lastname)
                .HasColumnName("lastname")
                .HasColumnType("varchar(70)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction.HasIndex(p => p.Code).IsUnique();
            buildAction.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CHK_CODE_NOT_EMPTY",
                    $"LTRIM(RTRIM(ISNULL([{nameof(Patient.Code)}], ''))) <> ''"
                );
                t.HasCheckConstraint(
                    "CHK_NAME_NOT_EMPTY",
                    $"LTRIM(RTRIM({nameof(Patient.Firstname)} + ' ' + {nameof(Patient.Lastname)})) <> ''"
                );
            });
        });

        // Seed data
        //modelBuilder.Entity<Department>().HasData(
        //    new Department { DepartmentId = Guid.NewGuid().ToString(), Name = "Cardiology", Description = "Heart and Cardiovascular Department" },
        //    new Department { DepartmentId = Guid.NewGuid().ToString(), Name = "Pediatrics", Description = "Children Health Department" },
        //    new Department { DepartmentId = Guid.NewGuid().ToString(), Name = "Orthopedics", Description = "Bone and Joint Department" },
        //    new Department { DepartmentId = Guid.NewGuid().ToString(), Name = "General Medicine", Description = "General Health Department" },
        //    new Department { DepartmentId = Guid.NewGuid().ToString(), Name = "Emergency", Description = "Emergency Department" }
        //);
    }
}
