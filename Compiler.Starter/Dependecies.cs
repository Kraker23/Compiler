using Compiler.BL;
using Compiler.EF;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Compiler.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Compiler.Starter
{
    static class Dependecies
    {
        public static void FillDependencies()
        {
            // load configs            
            var tj = Inject.Instance;            

            tj.AddServices = (s) =>
            {
                
                s.AddTransient<IManagerJson, ManagerJson>();
                //Data
                s.AddTransient<IProyecto_Data, Proyecto_EF>();
                s.AddTransient<IAplicacion_Data, Aplicacion_EF>();
                s.AddTransient<IArchivoExclusion_Data, ArchivoExclusion_EF>();
                //BL
                s.AddTransient<IAplicacion_BL, Aplicacion_BL>();
                s.AddTransient<IProyecto_BL, Proyecto_BL>();
                s.AddTransient<IArchivoExclusion_BL, ArchivoExclusion_BL>();

                s.AddTransient<frmCompilador>();
                s.AddTransient<frmConfiguracionAplicaciones>();
                s.AddTransient<frmConfiguracionArchivosExcluyentes>();
                s.AddTransient<frmConfiguracionProyectos>();
                s.AddTransient<frmMain>();
            };

            tj.Build();
            
        }
    }
}
