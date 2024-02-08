
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using Compiler.Starter;
using Compiler.UI.Controls;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Devices;
using Utilities.Clases.XML;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Compiler.UI
{
    public partial class frmConfiguracionAplicaciones : MetroForm
    {

        IAplicacion_BL managerAplicacion;
        IProyecto_BL managerProyecto;
        IArchivoExclusion_BL managerExclusion;
        ICarpeta_BL managerCarpeta;
        List<Aplicacion> aplicaciones;
        List<Carpeta> carpetas;

        cAplicacion ctrAplicacion = new cAplicacion();
        public frmConfiguracionAplicaciones()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();
            managerCarpeta = Inject.Instance.ServiceProvider.GetService<ICarpeta_BL>();

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
            carpetas = managerCarpeta.getCarpetas();
            treeAplicaciones.Nodes.Clear();
            foreach (Carpeta carpeta in carpetas.OrderBy(x => x.nombre))
            {
                TreeNode nodeCarpeta = new TreeNode(carpeta.nombre);
                nodeCarpeta.Tag = carpeta;

                if (aplicaciones.Any(x => x.fk_IdCarpeta == carpeta.id))
                {
                    int i = 0;
                    foreach (Aplicacion aplicacion in aplicaciones.Where(x => x.fk_IdCarpeta == carpeta.id))
                    {
                        TreeNode nodeAplicacion = new TreeNode(aplicacion.nombre);
                        nodeAplicacion.Tag = aplicacion;
                        nodeAplicacion.ImageIndex = iListTree.Images.IndexOfKey("window.png");
                        nodeAplicacion.SelectedImageIndex = iListTree.Images.IndexOfKey("window.png");
                        nodeCarpeta.Nodes.Add(nodeAplicacion);
                        i++;
                    }
                    nodeCarpeta.Text = $"{carpeta.nombre} [{i}]";
                }
                nodeCarpeta.ImageIndex = iListTree.Images.IndexOfKey("folder.png");
                nodeCarpeta.SelectedImageIndex = iListTree.Images.IndexOfKey("folder.png");
                treeAplicaciones.Nodes.Add(nodeCarpeta);
            }
            foreach (Aplicacion aplicacion in aplicaciones.Where(x => x.fk_IdCarpeta == null))
            {
                TreeNode node = new TreeNode(aplicacion.nombre);
                node.Tag = aplicacion;
                treeAplicaciones.Nodes.Add(node);
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            Aplicacion aux = new Aplicacion();

            bool esCarpeta = treeAplicaciones.SelectedNode.Tag.GetType() == typeof(Carpeta);
            aux.fk_IdCarpeta = esCarpeta ? ((Carpeta)treeAplicaciones.SelectedNode.Tag).id : null;
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
                bool esAplicacion = treeAplicaciones.SelectedNode.Tag.GetType() == typeof(Aplicacion);

                tsbEditCarpeta.Enabled = tsbDeleteCarpeta.Enabled = !esAplicacion;
                tsbDuplicar.Enabled = tsbBorrar.Enabled = esAplicacion;

                if (esAplicacion)
                {
                    ctrAplicacion.Enabled = ctrAplicacion.Visible = true;
                    TreeNode nodo = treeAplicaciones.SelectedNode;
                    Aplicacion aux = ((Aplicacion)nodo.Tag);
                    ctrAplicacion.set(aux);
                }
            }
        }

        private void ctrAplicacion_Guardar(Aplicacion aplicacion)
        {
            managerAplicacion.ModificarAplicacion(aplicacion);
            LoadData();
        }

        private void tsbAddCarpeta_Click(object sender, EventArgs e)
        {
            frmCrearNombre frmCrearNombre = new frmCrearNombre();
            if (frmCrearNombre.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(frmCrearNombre.resultado))
                {
                    Carpeta carpetaNew = new Carpeta();
                    carpetaNew.nombre = frmCrearNombre.resultado;
                    managerCarpeta.CrearCarpeta(carpetaNew);
                    LoadData();
                }
            }
        }

        private void tsbEditCarpeta_Click(object sender, EventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null && treeAplicaciones.SelectedNode.Tag.GetType() == typeof(Carpeta))
            {
                Carpeta carpetaSeleccionada = (Carpeta)treeAplicaciones.SelectedNode.Tag;

                frmCrearNombre frmCrearNombre = new frmCrearNombre(string.Empty, carpetaSeleccionada.nombre);
                if (frmCrearNombre.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(frmCrearNombre.resultado))
                    {
                        carpetaSeleccionada.nombre = frmCrearNombre.resultado;
                        managerCarpeta.ModificarCarpeta(carpetaSeleccionada);
                        LoadData();
                    }
                }
            }
        }

        private void tsbDeleteCarpeta_Click(object sender, EventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null && treeAplicaciones.SelectedNode.Tag.GetType() == typeof(Carpeta))
            {
                Carpeta carpetaSeleccionada = (Carpeta)treeAplicaciones.SelectedNode.Tag;

                if (managerCarpeta.ExisteCarpeta(carpetaSeleccionada.id))
                {
                    frmConfirmacion frmConfir = new frmConfirmacion("Borrar Carpeta", "Estas seguro que quiere borrar esta Carpeta '"
                        + carpetaSeleccionada.nombre + "' ?");
                    frmConfir.ShowDialog();
                    if (frmConfir.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        if (!managerAplicacion.AnyAplicacionConCarpeta(carpetaSeleccionada.id))
                        {
                            managerCarpeta.BorrarCarpeta(carpetaSeleccionada.id);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("No puedes borrar una Carpeta que este en alguna Aplicacion", "Borrar Carpeta",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No Existe la Carpeta", "Borrar Carpeta" + ((Aplicacion)treeAplicaciones.SelectedNode.Tag).nombre,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmTree_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null)
            {
                bool esAplicacion = treeAplicaciones.SelectedNode.Tag.GetType() == typeof(Aplicacion);

                if (esAplicacion)
                {
                    GenerarToolStripMenuItemCarpetas(((Aplicacion)treeAplicaciones.SelectedNode.Tag).fk_IdCarpeta);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void GenerarToolStripMenuItemCarpetas(Guid? idCarpeta)
        {
            this.tsmMoverCarpeta.DropDownItems.Clear();
            foreach (Carpeta carpeta in carpetas)
            {
                ToolStripMenuItem mniAuxiliar = new ToolStripMenuItem();
                mniAuxiliar.Name = "mniAuxiliar" + carpeta.nombre;
                mniAuxiliar.Size = new Size(180, 22);
                mniAuxiliar.Text = carpeta.nombre;
                mniAuxiliar.Enabled = idCarpeta != carpeta.id;
                mniAuxiliar.Tag = carpeta;
                mniAuxiliar.Click += new EventHandler(this.mniCarpeta_Click);
                this.tsmMoverCarpeta.DropDownItems.Add(mniAuxiliar);
            }
        }

        private void mniCarpeta_Click(object? sender, EventArgs e)
        {
            if (treeAplicaciones.SelectedNode != null && treeAplicaciones.SelectedNode.Tag.GetType() == typeof(Aplicacion))
            {
                Carpeta carpetaSeleccionada = ((Carpeta)((ToolStripMenuItem)sender).Tag);
                Aplicacion aplicacion = (Aplicacion)treeAplicaciones.SelectedNode.Tag;
                aplicacion.fk_IdCarpeta = carpetaSeleccionada.id;
                managerAplicacion.ModificarAplicacion(aplicacion);
                LoadData();
            }
        }
    }
}
