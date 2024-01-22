
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmConfiguracionAplicaciones : MetroForm
    {

        IAplicacion_Data managerAplicacion;
        List<Aplicacion> aplicaciones;
        public frmConfiguracionAplicaciones()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_Data>();
            managerAplicacion.Add(new Aplicacion { nombre = "test" });
            managerAplicacion.Add(new Aplicacion { nombre = "test1" });
            managerAplicacion.Add(new Aplicacion { nombre = "test2" });
            managerAplicacion.Add(new Aplicacion { nombre = "test3" });
        }

        private void frmConfiguracionAplicaciones_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            aplicaciones = managerAplicacion.GetAll();
            foreach (Aplicacion aplicacion in aplicaciones)
            {
                TreeNode node = new TreeNode(aplicacion.nombre);
                node.Tag = aplicacion;
                treeAplicaciones.Nodes.Add(node);
            }
        }
    }
}
