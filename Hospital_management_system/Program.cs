using Hospital_management_system.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Hospital_management_system;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        services.ConfigureServices();

        var provider = services.BuildServiceProvider();

        System.Windows.Forms
            .Application.Run(provider.GetRequiredService<MainForm>());
    }
}