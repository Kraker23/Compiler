using Compiler.EF;
using Compiler.Shared.Interface.IData;
using Compiler.UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Compiler.Starter
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            //Dependecies.FillDependencies();
            //Application.Run(new frmMain());



            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ///Cristian
            //var host = CreateHostBuilder().Build();
            //ServiceProvider = host.Services;           
            //Application.Run(ServiceProvider.GetRequiredService<frmAplicaciones>());
            //Application.Run(ServiceProvider.GetRequiredService<frmMain>());

            //Inject
            Dependecies.FillDependencies();
            Application.Run(new frmAplicaciones());

        }

      /*  public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddTransient<IManagerJson, ManagerJson>();
                    //Data
                    services.AddTransient<IProyecto_Data, Proyecto_EF>();
                    services.AddTransient<IAplicacion_Data, Aplicacion_EF>();
                    //BL
                    //services.AddTransient<IBL_Carpeta, BL_Carpeta>();
                    //services.AddTransient<IBL_Tarea, BL_Tarea>();
                    //services.AddTransient<IBL_Nota, BL_Nota>();

                    services.AddTransient<frmAplicaciones>();
                });
        }*/
    }
}