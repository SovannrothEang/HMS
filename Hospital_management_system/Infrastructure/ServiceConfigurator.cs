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
            options.UseSqlServer("""

                Data Source=localhost\\MSSQLSERVER2022;
                Initial Catalog=hms;
                Integrated Security=True;
                Persist Security Info=False;
                Pooling=False;
                MultipleActiveResultSets=False;
                Encrypt=False;
                TrustServerCertificate=False
                
                """);   
        });

        services.AddSingleton<MainForm>();
        services.AddTransient<LoginForm>();

        services.AddTransient<DashboardControl>();
        services.AddTransient<DoctorControl>();

        services.AddScoped<IDoctorRepository, DoctorRepository>();

        return services;
    }
}
