
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management;
using System.Management.Automation;
using System.Windows.Forms;
using Utilities.Clases.UtilidadesInterfaz;
using Utilities.Extensions;
using static System.Net.Mime.MediaTypeNames;
using DevToolsNet.PowerShell;
using System.Management.Automation.Runspaces;
using static DevToolsNet.PowerShell.IPowerShellRunner;
using System.Security;
using Namotion.Reflection;
using System.IO;
using Compiler.UI.Controls;
using System.Collections.Generic;
using Compiler.Shared.Extenders;

namespace Compiler.UI
{
    public partial class frmMain : MetroForm
    {
        public bool seVe = true;
        private bool cerrar = false;
        private ToolStripMenuItem mniVerPrograma;
        private ToolStripMenuItem mniCerrarPrograma;

        IProyecto_BL managerProyecto;
        IAplicacion_BL managerAplicacion;
        IArchivoExclusion_BL managerExclusion;
        List<Proyecto> proyectos;
        readonly string nombreArchivosExlcudes = "excludedfileslist.txt";
        PowerShell ps;
        public frmMain()
        {
            InitializeComponent();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadData();
            CargarMenuContextual();
            VerPrograma();
        }
        private void tsbRecargar_Click(object sender, EventArgs e)
        {
            CargarMenuContextual();
            LoadData();
        }
        private void LoadData()
        {
            proyectos = managerProyecto.getProyectos();
            treeProyectos.Nodes.Clear();
            foreach (Proyecto proyecto in proyectos)
            {
                TreeNode node = new TreeNode(proyecto.nombre);
                node.Tag = proyecto;
                //node.HideCheckBox();
                foreach (Guid idAplicacion in proyecto.aplicaciones)
                {
                    Aplicacion aplicacion = managerAplicacion.getAplicacion(idAplicacion);
                    TreeNode subAplicacion = GenerarSubNodo(aplicacion, aplicacion.nombre);
                    TreeNode subNodoCopiar = GenerarSubNodo(aplicacion, "Copiar");
                    TreeNode subNodoCompilar = GenerarSubNodo(aplicacion, "Compilar", false);
                    TreeNode subNodoCopiarCompilar = GenerarSubNodo(aplicacion, "Copiar y Compilar", false);
                    subAplicacion.Nodes.Add(subNodoCopiar);
                    subAplicacion.Nodes.Add(subNodoCompilar);
                    subAplicacion.Nodes.Add(subNodoCopiarCompilar);

                    node.Nodes.Add(subAplicacion);
                }
                node.Expand();
                treeProyectos.Nodes.Add(node);
            }
        }

        private TreeNode GenerarSubNodo(object objeto, string Texto, bool enable = true)
        {
            TreeNode node = new TreeNode(Texto);
            node.Checked = false;
            node.Tag = objeto;
            if (!enable)
            {
                node.ForeColor = SystemColors.GrayText;
            }
            return node;
        }

        private void treeProyectos_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (SystemColors.GrayText == e.Node.ForeColor)
                e.Cancel = true;
        }
        private void treeProyectos_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (SystemColors.GrayText == e.Node.ForeColor)
                e.Cancel = true;
        }

        #region ToolStrip y ContextMenu NotifyIcon
        private void tsmiAplicaciones_Click(object sender, EventArgs e)
        {
            Form frm = null;
            frm = GetFormularios(typeof(frmConfiguracionAplicaciones)).FirstOrDefault();
            if (frm == null)
            {
                frm = new frmConfiguracionAplicaciones();
                this.AddOwnedForm(frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void tsmiProyectos_Click(object sender, EventArgs e)
        {
            Form frm = null;
            frm = GetFormularios(typeof(frmConfiguracionProyectos)).FirstOrDefault();
            if (frm == null)
            {
                frm = new frmConfiguracionProyectos();
                this.AddOwnedForm(frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void tsmiArchivosExcluyentes_Click(object sender, EventArgs e)
        {
            Form frm = null;
            frm = GetFormularios(typeof(frmConfiguracionArchivosExcluyentes)).FirstOrDefault();
            if (frm == null)
            {
                frm = new frmConfiguracionArchivosExcluyentes();
                this.AddOwnedForm(frm);
                frm.Show();
            }
            else
            {
                frm.Activate();
            }
        }



        /// <summary>
        /// Recupera la lista de formularios de un tipo, existentes dentro del MDI
        /// </summary>
        /// <param name="tipo">Tipo del fomulario</param>
        /// <returns></returns>
        private List<Form> GetFormularios(Type tipo)
        {
            return this.OwnedForms.Where(form => form.GetType() == tipo).ToList();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {

            seVe = !seVe;
            VerPrograma();
        }

        private void mniVerPrograma_Click(object sender, EventArgs e)
        {
            seVe = !seVe;
            VerPrograma();
        }
        private void mniCerrar_Click(object sender, EventArgs e)
        {
            cerrar = true;
            this.Close();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrar)
            {
                seVe = !seVe;
                VerPrograma();
                e.Cancel = true;
            }
        }

        private void VerPrograma()
        {
            if (seVe)
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                this.Visible = true;
                mniVerPrograma.Text = "Minimizar Compiler";
                this.BringToFront();
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
                mniVerPrograma.Text = "Abrir Compiler";
                this.Visible = false;
            }
        }

        private void CargarMenuContextual()
        {
            this.cmBarraIconos.Items.Clear();
            ToolStripSeparator tsSeparatorAux = GenerarToolStripSeparator();

            GenerarToolStripMenuItem();
            tsSeparatorAux = GenerarToolStripSeparator();
            this.cmBarraIconos.Items.Add(tsSeparatorAux);

            mniVerPrograma = new ToolStripMenuItem();
            mniVerPrograma.Name = "mniVerPrograma";
            mniVerPrograma.Size = new Size(180, 22);
            mniVerPrograma.Text = "Ver Programa";
            mniVerPrograma.Click += new EventHandler(this.mniVerPrograma_Click);
            this.cmBarraIconos.Items.Add(mniVerPrograma);

            tsSeparatorAux = GenerarToolStripSeparator();
            this.cmBarraIconos.Items.Add(tsSeparatorAux);

            mniCerrarPrograma = new ToolStripMenuItem();
            mniCerrarPrograma.Name = "mniCerrar";
            mniCerrarPrograma.Size = new Size(180, 22);
            mniCerrarPrograma.Text = "Salir del Compiler";
            mniCerrarPrograma.Click += new EventHandler(this.mniCerrar_Click);
            this.cmBarraIconos.Items.Add(mniCerrarPrograma);
        }

        private static ToolStripSeparator GenerarToolStripSeparator()
        {
            ToolStripSeparator tsSeparatorAux = new ToolStripSeparator();
            tsSeparatorAux.Name = "tsSeparatorAux";
            tsSeparatorAux.Size = new Size(177, 6);
            return tsSeparatorAux;
        }

        private void GenerarToolStripMenuItem()
        {
            foreach (Proyecto proyecto in proyectos)
            {
                ToolStripMenuItem mniAuxiliar = new ToolStripMenuItem();
                mniAuxiliar.Name = "mniAuxiliar" + proyecto.nombre;
                mniAuxiliar.Size = new Size(180, 22);
                mniAuxiliar.Text = proyecto.nombre;
                mniAuxiliar.Tag = proyecto;

                ToolStripMenuItem mniCopiar = GenerarToolStripMenuItemCopiar(proyecto);
                mniAuxiliar.DropDownItems.Add(mniCopiar);
                ToolStripMenuItem mniCompilar = GenerarToolStripMenuItemCompilar(proyecto);
                mniAuxiliar.DropDownItems.Add(mniCompilar);
                ToolStripMenuItem mniCompilarCopiar = GenerarToolStripMenuItemCompilarCopiar(proyecto);
                mniAuxiliar.DropDownItems.Add(mniCompilarCopiar);

                mniAuxiliar.Click += new EventHandler(this.mniProyecto_Click);
                this.cmBarraIconos.Items.Add(mniAuxiliar);
            }
        }

        private ToolStripMenuItem GenerarToolStripMenuItemCopiar(Proyecto proyecto)
        {
            ToolStripMenuItem mniCopiar = new ToolStripMenuItem();
            mniCopiar.Name = "mniCopiar" + proyecto.nombre;
            mniCopiar.Size = new Size(180, 22);
            mniCopiar.Text = $"Copiar -> {proyecto.nombre}";
            mniCopiar.Tag = proyecto;
            mniCopiar.Click += new EventHandler(this.mniCopiar_Click);
            return mniCopiar;
        }
        private ToolStripMenuItem GenerarToolStripMenuItemCompilar(Proyecto proyecto)
        {
            ToolStripMenuItem mniCompilar = new ToolStripMenuItem();
            mniCompilar.Name = "mniCompilar" + proyecto.nombre;
            mniCompilar.Enabled = false;
            mniCompilar.Size = new Size(180, 22);
            mniCompilar.Text = $"Compilar -> {proyecto.nombre}";
            mniCompilar.Tag = proyecto;
            mniCompilar.Click += new EventHandler(this.mniCompilar_Click);
            return mniCompilar;
        }

        private ToolStripMenuItem GenerarToolStripMenuItemCompilarCopiar(Proyecto proyecto)
        {
            ToolStripMenuItem mniCompilarCopiar = new ToolStripMenuItem();
            mniCompilarCopiar.Name = "mniCompilarCopiar" + proyecto.nombre;
            mniCompilarCopiar.Enabled = false;
            mniCompilarCopiar.Size = new Size(180, 22);
            mniCompilarCopiar.Text = $"Compilar -> {proyecto.nombre}";
            mniCompilarCopiar.Tag = proyecto;
            mniCompilarCopiar.Click += new EventHandler(this.mniCompilarCopiar_Click);
            return mniCompilarCopiar;
        }

        #region Eventos Copiar y Compilar
        private void mniProyecto_Click(object sender, EventArgs e)
        {
            //TODO
        }
        private void mniCopiar_Click(object sender, EventArgs e)
        {
            Proyecto proyecto = ((Proyecto)((ToolStripMenuItem)sender).Tag);
            Copiar(proyecto);
        }
        private void mniCompilar_Click(object sender, EventArgs e)
        {
            Proyecto proyecto = ((Proyecto)((ToolStripMenuItem)sender).Tag);
            Compilar(proyecto);
        }

        private void mniCompilarCopiar_Click(object sender, EventArgs e)
        {
            Proyecto proyecto = ((Proyecto)((ToolStripMenuItem)sender).Tag);
            CompilarCopiar(proyecto);
        }
        #endregion
        #endregion


        #region ContextMenuTree

        private void cmTree_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (treeProyectos.SelectedNode != null &&
                (treeProyectos.SelectedNode.Tag.GetType() == typeof(Proyecto)
                || treeProyectos.SelectedNode.Tag.GetType() == typeof(Aplicacion)))
            {
                tsmCopiar.Enabled = true;
                tsmCompilar.Enabled = false;
                tsmCompilarCopiar.Enabled = false;
            }
            else
            {
                tsmCopiar.Enabled = false;
                tsmCompilar.Enabled = false;
                tsmCompilarCopiar.Enabled = false;
                e.Cancel = true;
            }
        }

        #region Eventos Copiar y Compilar
        private void tsmCopiar_Click(object sender, EventArgs e)
        {
            if (treeProyectos.SelectedNode != null)
            {
                TreeNode treeNode = treeProyectos.SelectedNode;
                if (treeProyectos.SelectedNode.Tag.GetType() == typeof(Proyecto))
                {
                    Proyecto proyecto = ((Proyecto)treeProyectos.SelectedNode.Tag);
                    Copiar(proyecto);
                }
                else if (treeProyectos.SelectedNode.Tag.GetType() == typeof(Aplicacion))
                {
                    Aplicacion aplicacion = ((Aplicacion)treeProyectos.SelectedNode.Tag);
                    Copiar(aplicacion);
                }
            }
        }

        private void tsmCompilar_Click(object sender, EventArgs e)
        {
            if (treeProyectos.SelectedNode != null)
            {
                TreeNode treeNode = treeProyectos.SelectedNode;
                if (treeProyectos.SelectedNode.Tag.GetType() == typeof(Proyecto))
                {
                    Proyecto proyecto = ((Proyecto)treeProyectos.SelectedNode.Tag);
                    Compilar(proyecto);
                }
                else if (treeProyectos.SelectedNode.Tag.GetType() == typeof(Aplicacion))
                {
                    Aplicacion aplicacion = ((Aplicacion)treeProyectos.SelectedNode.Tag);
                    Compilar(aplicacion);
                }
            }
        }

        private void tsmCompilarCopiar_Click(object sender, EventArgs e)
        {
            if (treeProyectos.SelectedNode != null)
            {
                TreeNode treeNode = treeProyectos.SelectedNode;
                if (treeProyectos.SelectedNode.Tag.GetType() == typeof(Proyecto))
                {
                    Proyecto proyecto = ((Proyecto)treeProyectos.SelectedNode.Tag);
                    CompilarCopiar(proyecto);
                }
                else if (treeProyectos.SelectedNode.Tag.GetType() == typeof(Aplicacion))
                {
                    Aplicacion aplicacion = ((Aplicacion)treeProyectos.SelectedNode.Tag);
                    CompilarCopiar(aplicacion);
                }
            }
        }
        #endregion   

        #endregion


        #region Copiar y Compilar
        private void Copiar(Proyecto proyecto)
        {
            var aplicacionesAux = managerAplicacion.getAplicaciones(proyecto.aplicaciones);
            foreach (Aplicacion aplicacion in aplicacionesAux)
            {
                EjecutarPS_Copiar(aplicacion);
            }
        }

        private void Compilar(Proyecto proyecto)
        {

        }

        private void CompilarCopiar(Proyecto proyecto)
        {

        }


        private void Copiar(Aplicacion aplicacion)
        {

        }

        private void Compilar(Aplicacion aplicacion)
        {

        }

        private void CompilarCopiar(Aplicacion aplicacion)
        {

        }
        #endregion

        #region EjecutarPS_Cristian
        public async void EjecutarPS_Cristian()
        {
            psBorrado();

            psExcludeArchivos();

            string pathOrigen = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea";
            string pathDestino = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea TEST";

            string script = $"xcopy \"{pathOrigen}\" \"{pathDestino}\" /E /S /Y /D /exclude:{nombreArchivosExlcudes}";
            txtPS.Text += script + Environment.NewLine + Environment.NewLine;

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += Progress_DataAdded;

            PowerShell psinstance = PowerShell.Create();
            psinstance.AddScript(script);


            var r = await Task.Factory.StartNew<IAsyncResult>(() => psinstance.BeginInvoke<PSObject, PSObject>(null, output));
        }

        public async void EjecutarPS_Copiar(Aplicacion aplicacion)
        {
            crearArchivosExcluidos(aplicacion.archivosExcluidos);

            string script = $"xcopy \"{aplicacion.carpetaCompilado}\" \"{aplicacion.carpetaPublicacion}\" /E /S /Y /D /exclude:{nombreArchivosExlcudes}";

            txtPS.Text += $"-------------- COPIAR ------->>>> {aplicacion.nombre.ToUpper()}--------------  {Environment.NewLine} {Environment.NewLine}";
            txtPS.Text += $"{script}{Environment.NewLine} {Environment.NewLine}";

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += Progress_DataAdded;

            PowerShell psinstance = PowerShell.Create();
            psinstance.AddScript(script);


            var r = await Task.Factory.StartNew<IAsyncResult>(() => psinstance.BeginInvoke<PSObject, PSObject>(null, output));
        }

        private void Progress_DataAdded(object? sender, DataAddedEventArgs e)
        {
            PSObject newRecord = ((PSDataCollection<PSObject>)sender)[e.Index];

            txtPS.BeginInvoke(new Action(() => { txtPS.AppendText($"[{e.Index}] {newRecord.BaseObject} {Environment.NewLine}"); }));
            progresBar.BeginInvoke(new Action(() => { progresBar.Value = e.Index; }));
            progressSpinner.BeginInvoke(new Action(() => { progressSpinner.Value = e.Index; }));
        }


        private async void toolStripButton1_Click(object sender, EventArgs e)
        {

            progressSpinner.Maximum = progresBar.Maximum = 600;

            progressSpinner.Visible = progresBar.Visible = true;

             EjecutarPS_Cristian();
            //EjecutarPS();


        }


        public void psBorrado()
        {
            string pathDestino = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea TEST";
            string scriptBorrar = $"Remove-Item \"{pathDestino}\\*\" -Recurse -Force";
            PowerShell psinstanceBorrado = PowerShell.Create();
            psinstanceBorrado.AddScript(scriptBorrar);
            var resultsBorrado = psinstanceBorrado.Invoke();
        }
        public void psExcludeArchivos()
        {
            var archivos = managerExclusion.getArchivoExclusiones();

            string archivosExcluir = archivos.getArchivosToString();

            if (File.Exists(nombreArchivosExlcudes))
            {
                File.Delete(nombreArchivosExlcudes);
            }
            using (StreamWriter sw = File.CreateText(nombreArchivosExlcudes))
            {
                sw.WriteLine(archivosExcluir);
            }
        }
        public void crearArchivosExcluidos(List<Guid> idsArchivos)
        {
            var archivos = managerExclusion.getArchivoExclusiones(idsArchivos);

            string archivosExcluir = archivos.getArchivosToString();

            if (File.Exists(nombreArchivosExlcudes))
            {
                File.Delete(nombreArchivosExlcudes);
            }
            using (StreamWriter sw = File.CreateText(nombreArchivosExlcudes))
            {
                sw.WriteLine(archivosExcluir);
            }
        }

        #endregion
    }



}
