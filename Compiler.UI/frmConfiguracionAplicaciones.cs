
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using Compiler.UI.Controls;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Compiler.UI
{
    public partial class frmConfiguracionAplicaciones : MetroForm
    {

        IAplicacion_BL managerAplicacion;
        IProyecto_BL managerProyecto;
        IArchivoExclusion_BL managerExclusion;
        List<Aplicacion> aplicaciones;

        cAplicacion ctrAplicacion = new cAplicacion();
        public frmConfiguracionAplicaciones()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();

            CrearControlAplicacion();
        }

        private void CrearControlAplicacion()
        {
            ctrAplicacion.Dock = DockStyle.Fill;
            ctrAplicacion.Location = new Point(332, 30);
            ctrAplicacion.Name = "ctrAplicacion";
            ctrAplicacion.TabIndex = 4;
            ctrAplicacion.UseSelectable = true;
            ctrAplicacion.Guardar += ctrAplicacion_Guardar;
            pAplicacion.Controls.Add(ctrAplicacion);

        }

        private void frmConfiguracionAplicaciones_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            ctrAplicacion.Enabled = ctrAplicacion.Visible = false;
            aplicaciones = managerAplicacion.getAplicaciones();
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
            Aplicacion aux = new Aplicacion();

            TreeNode node = new TreeNode(aux.nombre);
            node.Tag = aux;
            treeAplicaciones.Nodes.Add(node);
            treeAplicaciones.SelectedNode = node;
        }
        private void tsbDuplicar_Click(object sender, EventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null)
            {
                TreeNode nodo = treeAplicaciones.SelectedNode;
                Aplicacion copiar = ((Aplicacion)nodo.Tag);

                Aplicacion aux = new Aplicacion();
                aux.nombre = copiar.nombre;
                aux.ubicacionAplicacion = copiar.ubicacionAplicacion;
                aux.carpetaPublicacion = copiar.carpetaPublicacion;
                aux.carpetaCompilado = copiar.carpetaCompilado;
                aux.comandoCompilado = copiar.comandoCompilado;
                aux.archivosExcluidos = copiar.archivosExcluidos;

                TreeNode node = new TreeNode(aux.nombre);
                node.Tag = aux;
                treeAplicaciones.Nodes.Add(node);
                treeAplicaciones.SelectedNode = node;
            }
        }
        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null)
            {
                TreeNode nodo = treeAplicaciones.SelectedNode;
                if (managerAplicacion.ExisteAplicacion(((Aplicacion)nodo.Tag).id))
                {
                    frmConfirmacion frmConfir = new frmConfirmacion("Borrar Aplicacion", "Estas seguro que quiere borrar esta Aplicacion '"
                        + ((Aplicacion)treeAplicaciones.SelectedNode.Tag).nombre + "' ?");
                    frmConfir.ShowDialog();
                    if (frmConfir.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!managerProyecto.AnyProyectoConAplicacion(((Aplicacion)nodo.Tag).id))
                        {
                            managerAplicacion.BorrarAplicacion(((Aplicacion)nodo.Tag).id);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No puedes borrar una Aplicacion que este en algun Proyecto", "Borrar Aplicacion",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Existe la Aplicacion", "Borrar Aplicacion" + ((Aplicacion)treeAplicaciones.SelectedNode.Tag).nombre,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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
            managerAplicacion.ModificarAplicacion(aplicacion);
            LoadData();
        }


    }
}
