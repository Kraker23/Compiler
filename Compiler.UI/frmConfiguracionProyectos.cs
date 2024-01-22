
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmConfiguracionProyectos : MetroForm
    {

        IAplicacion_Data managerAplicacion;
        IProyecto_Data managerProyecto;
        List<Aplicacion> aplicaciones;
        List<Proyecto> proyectos;
        public frmConfiguracionProyectos()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_Data>();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_Data>();
        }

        private void frmConfiguracionProyectos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            aplicaciones = managerAplicacion.GetAll();
            proyectos = managerProyecto.GetAll();
            foreach (Proyecto proyecto in proyectos)
            {
                TreeNode node = new TreeNode(proyecto.nombre);
                node.Tag = proyecto;
                treeProyectos.Nodes.Add(node);
            }
        }
    }
}
