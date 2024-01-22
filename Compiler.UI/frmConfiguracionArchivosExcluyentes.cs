
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmConfiguracionArchivosExcluyentes : MetroForm
    {

        IArchivoExclusion_Data managerExclusion;
        List<ArchivoExclusion> archivoExclusions;
        public frmConfiguracionArchivosExcluyentes()
        {
            InitializeComponent();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_Data>();
        }

        private void frmConfiguracionArchivosExcluyentes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            archivoExclusions = managerExclusion.GetAll();
            foreach (ArchivoExclusion archivo in archivoExclusions)
            {
                TreeNode node = new TreeNode(archivo.texto);
                node.Tag = archivo;
                treeAplicaciones.Nodes.Add(node);
            }
        }
    }
}
