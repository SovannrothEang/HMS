using Hospital_mangement_system.Application.Interfaces;
using Hospital_mangement_system.Domain.Repositories;
using Hospital_mangement_system.Infrastructure.Persistence;
using Hospital_mangement_system.Infrastructure.Persistence.Repositories;
using Hospital_mangement_system.Infrastructure.Services;
using Hospital_mangement_system.Presentation.UserControls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_mangement_system.Infrastructure;

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

        services.AddTransient<Dashboard>();
        services.AddTransient<Doctor>();

        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IDoctorService, DoctorService>();

        return services;
    }
}
