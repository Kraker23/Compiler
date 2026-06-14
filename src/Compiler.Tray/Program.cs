using Compiler.Application;
using Compiler.Infrastructure;
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

        var services = new ServiceCollection();
        services.AddApplicationServices();
        services.AddInfrastructureServices();
        services.AddTransient<Form1>();

        using var serviceProvider = services.BuildServiceProvider();
        var form = serviceProvider.GetRequiredService<Form1>();
        System.Windows.Forms.Application.Run(form);
    }    
}