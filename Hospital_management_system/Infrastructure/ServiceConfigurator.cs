using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Infrastructure.Persistence;
using Hospital_management_system.Infrastructure.Persistence.Repositories;
using Hospital_management_system.Presentation.Forms;
using Hospital_management_system.Presentation.UserControls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration; // Added
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_management_system.Infrastructure;

public static class ServiceConfigurator
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Get IConfiguration from the service collection
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddSingleton<MainForm>();
        services.AddTransient<LoginForm>();

        services.AddTransient<DashboardControl>();
        services.AddTransient<DepartmentControl>();
        services.AddTransient<DoctorControl>();
        services.AddTransient<PatientControl>();
        services.AddTransient<StaffControl>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();

        return services;
    }
}
