
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmConfiguracionProyectos : MetroForm
    {

        IAplicacion_BL managerAplicacion;
        IProyecto_BL managerProyecto;
        IArchivoExclusion_BL managerExclusion;
        List<Aplicacion> aplicaciones;
        List<Proyecto> proyectos;
        public frmConfiguracionProyectos()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();
        }

        private void frmConfiguracionProyectos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            aplicaciones = managerAplicacion.getAplicaciones();
            proyectos = managerProyecto.getProyectos();
            foreach (Proyecto proyecto in proyectos)
            {
                TreeNode node = new TreeNode(proyecto.nombre);
                node.Tag = proyecto;
                treeProyectos.Nodes.Add(node);
            }
        }
    }
}
