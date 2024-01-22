
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmAplicaciones : MetroForm
    {

        IAplicacion_Data managerAplicacion;
        List<Aplicacion > aplicaciones;
        public frmAplicaciones()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_Data>();
            
        }
    }
}
