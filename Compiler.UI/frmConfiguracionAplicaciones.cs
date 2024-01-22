
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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
        }

        private void frmConfiguracionAplicaciones_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ctrAplicacion.Enabled = ctrAplicacion.Visible = false;
            aplicaciones = managerAplicacion.GetAll();
            treeAplicaciones.Nodes.Clear();
            foreach (Aplicacion aplicacion in aplicaciones)
            {
                TreeNode node = new TreeNode(aplicacion.nombre);
                node.Tag = aplicacion;
                treeAplicaciones.Nodes.Add(node);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null)
            {
                TreeNode nodo = treeAplicaciones.SelectedNode;
                //if (bl_Proyecto.ExisteCarpeta(((Aplicacion)nodo.Tag).id))
                //{
                //    frmConfirmacion frmConfir = new frmConfirmacion("Borrar Aplicacion", "Estas seguro que quiere borrar esta Carpeta '" + ((Aplicacion)treeAplicaciones.SelectedNode.Tag).Nombre + "' ?");
                //    frmConfir.ShowDialog();
                //    if (frmConfir.DialogResult == System.Windows.Forms.DialogResult.OK)
                //    {
                //        if (bl_Aplicacion.ExisteCarpeta(((Aplicacion)nodo.Tag).id))
                //        {
                //            bl_Aplicacion.BorrarCarpeta(((Aplicacion)nodo.Tag).id);
                //        }
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("No puedes borrar una Aplicacion que este en algun Proyecto",
                //            "Borrar Carpeta",
                //            MessageBoxButtons.OK,
                //            MessageBoxIcon.Information);
                //}
            }

        }

        private void treeAplicaciones_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null)
            {
                ctrAplicacion.Enabled = ctrAplicacion.Visible = true;
                TreeNode nodo = treeAplicaciones.SelectedNode;
                Aplicacion aux = ((Aplicacion)nodo.Tag);
                ctrAplicacion.set(aux);
            }
        }

        private void ctrAplicacion_Guardar(Aplicacion aplicacion)
        {
            managerAplicacion.Update(aplicacion);
            managerAplicacion.SaveData();
            LoadData();
        }
    }
}
