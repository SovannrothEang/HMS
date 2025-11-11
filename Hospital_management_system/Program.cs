using Hospital_management_system.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Hospital_management_system;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        try
        {
            ApplicationConfiguration.Initialize();

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.ConfigureServices();

            var provider = services.BuildServiceProvider();

            System.Windows.Forms
                .Application.Run(provider.GetRequiredService<MainForm>());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Application startup error: {ex.Message}", "Critical Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
        ;
    }
}
