using Compiler.Application;
using Compiler.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.Tray;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .Build();

        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddSingleton(new TraySettings
        {
            WebUrl = configuration["Tray:WebUrl"] ?? "http://localhost:5000/proyectos",
            AutoOpenWebOnStart = bool.TryParse(configuration["Tray:AutoOpenWebOnStart"], out var autoOpen) && autoOpen
        });
        services.AddInfrastructureServices(configuration["Storage:DataDirectory"]);
        services.AddTransient<Form1>();

        using var serviceProvider = services.BuildServiceProvider();
        var form = serviceProvider.GetRequiredService<Form1>();
        System.Windows.Forms.Application.Run(form);
    }    
}