using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Infrastructure.Persistence;
using Hospital_management_system.Infrastructure.Persistence.Repositories;
using Hospital_management_system.Presentation.Forms;
using Hospital_management_system.Presentation.UserControls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_management_system.Infrastructure;

public static class ServiceConfigurator
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(
                @"Data Source=localhost\MSSQLSERVER2022;Initial Catalog=hms;Integrated Security=True;TrustServerCertificate=True;");
        });

        services.AddSingleton<MainForm>();
        services.AddTransient<LoginForm>();

        services.AddTransient<DashboardControl>();
        services.AddTransient<DepartmentControl>();
        services.AddTransient<DoctorControl>();

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IDoctorRepository, DoctorRepository>();

        return services;
    }
}
