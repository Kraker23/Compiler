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
            /*
            var tj = TUVject.Instance;
            tj.App = "SICER.Linea.UI";
            tj.Group = "Centro_" + BL.Globales.Linea.IdCentro.ToString();
            tj.ApiRecoverConfig = new TuvFrameworkSpainBSM.AppConfig.APIRecover.AppConfigAPIRecoverConfig()
            {
                BaseUrl = "https://central.es.tuv.group/TUVAppConfigAPI/",
                ApiKey = "Te$tDe$arroll0",
                UseDefaultCredentials = false,
                UseUserPassToken = false,
                Name = "TUVAppConfigAPI"
            };
            tj.ImportarConfigsFromAPI(out string err);
            if (!string.IsNullOrEmpty(err))
            {
                tj.AddJsonConfigFile($"configbkp_{tj.App}.json");
                MessageBox.Show("Error al cargar la configuración de la aplicación");
            }

            tj.AddServices = (s) =>
            {
                s.Configure<LineaDataApiClientConfig>(tj.Configuration.GetSection("SicerAPIClientConfig"));
                s.Configure<SeguridadDataApiClientConfig>(tj.Configuration.GetSection("SicerAPIClientConfig"));
                s.Configure<GlobalDataApiClientConfig>(tj.Configuration.GetSection("SicerAPIClientConfig"));
                s.Configure<InspectionQueueClientConfig>(tj.Configuration.GetSection("SicerAPIClientConfig"));
                s.Configure<InspectionFileManagerClientConfig>(tj.Configuration.GetSection("SicerAPIClientConfig"));

                s.Configure<FilesApiConfig>(tj.Configuration.GetSection("FilesApiConfig"));
                s.Configure<DigitalSignatureApiClientConfig>(tj.Configuration.GetSection("DigitalSignatureApiClientConfig"));


                s.AddTransient<IInspeccionReportData, LineaDataApiClient>();
                s.AddTransient<IInspeccionLineaFicheroData, LineaDataApiClient>();
                s.AddTransient<IInspeccionData, LineaDataApiClient>();
                s.AddTransient<IConfiguracionData, GlobalDataApiClient>();
                s.AddTransient<ITipoContenidoData, GlobalDataApiClient>();
                s.AddTransient<IConfigManager, GlobalDataApiClient>();
                s.AddTransient<IUsuarioData, SeguridadDataApiClient>();
                s.AddTransient<IUsuarioData, SeguridadDataApiClient>();
                s.AddTransient<IFilesClient, FilesApiClient>();

                s.AddTransient<ISignPDF, DigitalSignatureApiClient>();

                s.AddTransient<IConfigManager, GlobalDataApiClient>();
                s.AddTransient<IInspectionQueueData, InspectionQueueClient>();
                s.AddTransient<ILineInspectionFileManager, InspeccionLineaFicheroManager>();
                s.AddTransient<IInspeccionReportManager, InspeccionReportManager>();
            };

            tj.Build();
            */
        }
    }
}
