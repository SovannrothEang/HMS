using Hospital_management_system.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hospital_management_system.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Staff> Staffs { get; set; }

    public override Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        try
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified &&
                    (e.Entity is Department || e.Entity is Staff ||
                     e.Entity is Patient || e.Entity is Appointment));
            foreach (var entry in entries)
            {
                if (entry.Entity is Department dept)
                    dept.UpdatedAt = DateTime.UtcNow.AddHours(7);
                else if (entry.Entity is Staff staff)
                    staff.UpdatedAt = DateTime.UtcNow.AddHours(7);
                else if (entry.Entity is Patient patient)
                    patient.UpdatedAt = DateTime.UtcNow.AddHours(7);
                else if (entry.Entity is Appointment appointment)
                    appointment.UpdatedAt = DateTime.UtcNow.AddHours(7);
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
        modelBuilder.Entity<Appointment>(buildAction =>
        {
            buildAction.HasIndex(a => a.AppointmentDate);
            buildAction
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);
            buildAction
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
        });

        modelBuilder.Entity<Department>(buildAction =>
        {
            buildAction
                .Property(d => d.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(255)")
                .UseCollation("SQL_Latin1_General_CP850_BIN");
            buildAction
                .HasIndex(d => d.Name)
                .IsUnique()
                .HasFilter("name <> ''");
        });
        
        modelBuilder.Entity<Doctor>(buildAction =>
        {
            buildAction.HasIndex(d => d.LicenseNumber).IsUnique();
            buildAction.HasIndex(d => d.Specialization);

            buildAction
                .HasOne(d => d.Staff)
                .WithOne(s => s.Doctor)
                .HasForeignKey<Doctor>(d => d.DoctorId);
        });
        
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
            buildAction.HasIndex(s => s.Code).IsUnique();
            buildAction.HasIndex(s => s.DepartmentId);

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
                .HasForeignKey(d => d.DepartmentId);
        });

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
            buildAction.HasIndex(p => p.Code).IsUnique();
            buildAction.HasIndex(p => new { p.FirstName, p.LastName });

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
