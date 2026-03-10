using Hospital_management_system.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Windows.Forms;
using Hospital_management_system.Presentation.Forms;

namespace Hospital_management_system;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // 1. Setup Global Exception Handlers to prevent application crashes
        System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        System.Windows.Forms.Application.ThreadException += GlobalThreadExceptionHandler;
        AppDomain.CurrentDomain.UnhandledException += GlobalDomainExceptionHandler;
        TaskScheduler.UnobservedTaskException += GlobalUnobservedTaskExceptionHandler;

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

            System.Windows.Forms.Application.Run(provider.GetRequiredService<MainForm>());
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Application startup error: {ex.Message}", "Critical Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(1);
        }
    }

    private static void GlobalThreadExceptionHandler(object sender, ThreadExceptionEventArgs e)
    {
        ShowErrorDialog(e.Exception, "UI Thread");
    }

    private static void GlobalDomainExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        var ex = e.ExceptionObject as Exception;
        ShowErrorDialog(ex, "Background Thread");
    }

    private static void GlobalUnobservedTaskExceptionHandler(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        e.SetObserved(); // CRITICAL: This prevents the application from terminating due to unobserved async task exceptions
        ShowErrorDialog(e.Exception, "Async Task");
    }

    private static void ShowErrorDialog(Exception? ex, string source)
    {
        string errorMessage = ex?.Message ?? "An unknown error occurred.";
        
        // Prevent recursive crashes if the error dialog itself fails
        try 
        {
            MessageBox.Show(
                $"An unexpected error occurred.\n\nSource: {source}\nError: {errorMessage}\n\nThe application will attempt to ignore this error and continue running.", 
                "System Error Prevented", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Warning);
        }
        catch 
        {
            // If we can't even show the message box, just swallow the error to keep the app alive
        }
    }
}
