
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using Compiler.UI.Controls;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmConfiguracionArchivosExcluyentes : MetroForm
    {

        IArchivoExclusion_BL managerExclusion;
        IAplicacion_BL managerAplicacion;
        List<ArchivoExclusion> archivoExclusions;
        public frmConfiguracionArchivosExcluyentes()
        {
            InitializeComponent();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
        }

        private void frmConfiguracionArchivosExcluyentes_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ctrArchivoExclusion.Enabled = ctrArchivoExclusion.Visible = false;
            archivoExclusions = managerExclusion.getArchivoExclusiones();
            treeArchivos.Nodes.Clear();
            foreach (ArchivoExclusion archivo in archivoExclusions)
            {
                TreeNode node = new TreeNode(archivo.ToString());
                node.Tag = archivo;
                treeArchivos.Nodes.Add(node);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            ArchivoExclusion aux = new ArchivoExclusion();

            TreeNode node = new TreeNode(aux.ToString());
            node.Tag = aux;
            treeArchivos.Nodes.Add(node);
            treeArchivos.SelectedNode = node;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (treeArchivos.SelectedNode != null)
            {
                TreeNode nodo = treeArchivos.SelectedNode;
                if (managerExclusion.ExisteArchivoExclusion(((ArchivoExclusion)nodo.Tag).id))
                {
                    frmConfirmacion frmConfir = new frmConfirmacion("Borrar Archivo Exclusion", "Estas seguro que quiere borrar esta Archivo '"
                        + ((ArchivoExclusion)treeArchivos.SelectedNode.Tag).texto + "' ?");
                    frmConfir.ShowDialog();
                    if (frmConfir.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!managerAplicacion.AnyAplicacionConArchivoExclusion(((ArchivoExclusion)nodo.Tag).id))
                        {
                            managerExclusion.BorrarArchivoExclusion(((ArchivoExclusion)nodo.Tag).id);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No puedes borrar un Archivo que este en alguna Aplicacion", "Borrar Archivo Exclusion",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Existe el Archivo Exclusion", "Borrar Archivo Exclusion"
                            + ((ArchivoExclusion)treeArchivos.SelectedNode.Tag).texto,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void treeArchivos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeArchivos.SelectedNode != null)
            {
                ctrArchivoExclusion.Enabled = ctrArchivoExclusion.Visible = true;
                TreeNode nodo = treeArchivos.SelectedNode;
                ArchivoExclusion aux = ((ArchivoExclusion)nodo.Tag);
                ctrArchivoExclusion.set(aux);
            }
        }

        private void ctrArchivoExclusion_Guardar(ArchivoExclusion archivo)
        {
            managerExclusion.ModificarArchivoExclusion(archivo);
            LoadData();
        }
    }
}
