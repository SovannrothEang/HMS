using System.Reflection;
using Hospital_management_system.Application.Common;
using Hospital_management_system.Domain.Repositories;
using Hospital_management_system.Infrastructure.Persistence;
using Hospital_management_system.Infrastructure.Persistence.Repositories;
using Hospital_management_system.Presentation.Forms;
using Hospital_management_system.Presentation.UserControls;
using Microsoft.Extensions.Configuration; // Added
using Microsoft.Extensions.DependencyInjection;
using Dapper;

namespace Hospital_management_system.Infrastructure;

public static class ServiceConfigurator
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        // Global Dapper configuration
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        // Get IConfiguration from the service collection
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection") 
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        // ADO.NET / Dapper Infrastructure
        services.AddSingleton<IDbConnectionFactory>(new SqlConnectionFactory(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Application Layer - Mediator
        services.AddScoped<IMediator, Mediator>();
        services.RegisterHandlers();

        services.AddSingleton<MainForm>();
        services.AddTransient<LoginForm>();

        services.AddTransient<DashboardControl>();
        services.AddTransient<DepartmentsControl>();
        services.AddTransient<DoctorsControl>();
        services.AddTransient<PatientsControl>();
        services.AddTransient<StaffsControl>();
        services.AddTransient<UsersControl>();
        services.AddTransient<PositionsControl>();

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IStaffRepository, StaffRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();

        return services;
    }

    private static void RegisterHandlers(this IServiceCollection services)
    {
        var handlerType = typeof(IRequestHandler<,>);
        var assemblies = new[] { Assembly.GetExecutingAssembly() };

        foreach (var assembly in assemblies)
        {
            var handlers = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerType));

            foreach (var handler in handlers)
            {
                var interfaceType = handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerType);
                services.AddScoped(interfaceType, handler);
            }
        }
    }
}

