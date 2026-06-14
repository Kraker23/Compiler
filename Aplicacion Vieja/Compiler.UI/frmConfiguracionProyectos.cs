
using Compiler.Shared;
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Compiler.UI.Controls;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Compiler.UI
{
    public partial class frmConfiguracionProyectos : MetroForm
    {

        IAplicacion_BL managerAplicacion;
        IProyecto_BL managerProyecto;
        List<Aplicacion> aplicaciones;
        List<Proyecto> proyectos;

        cProyecto ctrProyecto = new cProyecto();
        public frmConfiguracionProyectos()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();

            CrearControlProyecto();
        }

        private void frmConfiguracionProyectos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ctrProyecto.Enabled = ctrProyecto.Visible = false;
            treeProyectos.Nodes.Clear();
            proyectos = managerProyecto.getProyectos();
            foreach (Proyecto proyecto in proyectos)
            {
                TreeNode node = new TreeNode(proyecto.nombre);
                node.Tag = proyecto;
                treeProyectos.Nodes.Add(node);
            }
        }
        private void CrearControlProyecto()
        {
            ctrProyecto.Dock = DockStyle.Fill;
            ctrProyecto.Location = new Point(332, 30);
            ctrProyecto.Name = "ctrProyecto";
            ctrProyecto.TabIndex = 4;
            ctrProyecto.UseSelectable = true;
            ctrProyecto.Guardar += ctrProyecto_Guardar;
            pProyecto.Controls.Add(ctrProyecto);
        }


        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Proyecto aux = new Proyecto();

            TreeNode node = new TreeNode(aux.nombre);
            node.Tag = aux;
            treeProyectos.Nodes.Add(node);
            treeProyectos.SelectedNode = node;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (treeProyectos.SelectedNode != null)
            {
                TreeNode nodo = treeProyectos.SelectedNode;
                if (managerProyecto.ExisteProyecto(((Proyecto)nodo.Tag).id))
                {
                    frmConfirmacion frmConfir = new frmConfirmacion("Borrar Proyecto", "Estas seguro que quiere borrar este Proyecto '"
                        + ((Proyecto)treeProyectos.SelectedNode.Tag).nombre + "' ?");
                    frmConfir.ShowDialog();
                    if (frmConfir.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        managerProyecto.BorrarProyecto(((Proyecto)nodo.Tag).id);
                        LoadData();
                    }
                }
                else
                {
                    MessageBox.Show("No Existe el Proyecto", "Borrar Proyecto" + ((Proyecto)treeProyectos.SelectedNode.Tag).nombre,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void treeProyectos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeProyectos.SelectedNode != null)
            {
                ctrProyecto.Enabled = ctrProyecto.Visible = true;
                TreeNode nodo = treeProyectos.SelectedNode;
                Proyecto aux = ((Proyecto)nodo.Tag);
                ctrProyecto.set(aux);
            }
        }

        private void ctrProyecto_Guardar(Proyecto proyecto)
        {
            managerProyecto.ModificarProyecto(proyecto);
            LoadData();
        }
    }
}
