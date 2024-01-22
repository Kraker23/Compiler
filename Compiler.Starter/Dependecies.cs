using Compiler.EF;
using Compiler.Shared.Interface.IData;
using Compiler.UI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*using DevToolsNet.AppConfig;
using DigitalSignature.APIClient;
using DigitalSignature.Shared.Interfaces;
using DNOTA.Linea.BL.LineaService;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.DependencyInjection;
using SICER.Global.ApiClient;
using SICER.Global.Shared.BLInterfaces;
using SICER.Global.Shared.Interfaces;
using SICER.Linea.ApiClient;
using SICER.Linea.BL;
using SICER.Linea.Shared.BLInterfaces;
using SICER.Linea.Shared.Interfaces;
using SICER.Seguridad.ApiClient;
using SICER.Seguridad.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using TUV.ES.Files.APIClient;
using TUV.ES.Files.Shared.Interfaces;
using TuvFrameworkSpainBSM.WinForms;
 * 
 * */
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
                //services.AddTransient<IBL_Carpeta, BL_Carpeta>();
                //services.AddTransient<IBL_Tarea, BL_Tarea>();
                //services.AddTransient<IBL_Nota, BL_Nota>();

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
