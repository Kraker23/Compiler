
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


            //string pathOrigen = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER LineaTest";
            string pathOrigen = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea";
            string pathDestino = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea TEST";

            string script = $"xcopy \"{pathOrigen}\" \"{pathDestino}\" /E /S /Y /D ";
            txtPS.Text += script + Environment.NewLine + Environment.NewLine;

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += Progress_DataAdded;

            PowerShell psinstance = PowerShell.Create();
            psinstance.AddScript(script);
            //psinstance.Streams.Progress.DataAdded += Progress_DataAdded;

            //var results = psinstance.Invoke();
            //var res = psinstance.BeginInvoke<PSObject, PSObject>(null, output);
            //res.AsyncWaitHandle.WaitOne();


            var r = await Task.Factory.StartNew<IAsyncResult>(() => psinstance.BeginInvoke<PSObject, PSObject>(null, output));
            
            //var r = await Task.Factory.StartNew<IPowerShellRunner>(() => new PowerShellRunner()).WaitAsync(CancellationToken.None);
            //if (r != null)
            //{
            //    progressSpinner.Visible = progresBar.Visible = false;
            //}

            /*
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                //use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                //use "AddCommand" to add individual commands/ cmdlets to the end of the execution pipeline.
                
                PowerShellInstance.AddScript(script);
                PowerShellInstance.Streams.Progress.DataAdded += Progress_DataAdded;
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();



                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        txtPS.Text += outputItem.ToString() + Environment.NewLine;
                    }
                }
                if (PowerShellInstance.Streams.Error.Count > 0)
                {
                    foreach (var error in PowerShellInstance.Streams.Error)
                    {
                        txtError.Text += error.ToString() + Environment.NewLine;

                    }
                }



            }
            */
        }

        private void Progress_DataAdded(object? sender, DataAddedEventArgs e)
        {
            PSObject newRecord = ((PSDataCollection<PSObject>)sender)[e.Index];
            // ProgressRecord newRecord = ((PSDataCollection<ProgressRecord>)sender)[e.Index];

            //txtPS.Text += $"[{e.Index}] {newRecord.BaseObject} {Environment.NewLine}";

            txtPS.BeginInvoke(new Action(() => { txtPS.AppendText($"[{e.Index}] {newRecord.BaseObject} {Environment.NewLine}"); }));
            progresBar.BeginInvoke(new Action(() => { progresBar.Value = e.Index; }));
            progressSpinner.BeginInvoke(new Action(() => { progressSpinner.Value = e.Index; }));
        }

        public event MessageOutDelegate ErrorMessaje;
        public event MessageOutDelegate WarningMessaje;
        public event MessageOutDelegate InfoMessaje;
        public event MessageOutDelegate TextMessaje;

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {

            progressSpinner.Maximum = progresBar.Maximum = 600;

            progressSpinner.Visible = progresBar.Visible = true;
            EjecutarPS_Cristian();

            //psBorrado();

            //await createRunner("hola");

        }

        PowerShell ps;

        public void psBorrado()
        {
            string pathDestino = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea TEST";
            string scriptBorrar = $"Remove-Item \"{pathDestino}\\*\" -Recurse -Force";
            PowerShell psinstanceBorrado = PowerShell.Create();
            psinstanceBorrado.AddScript(scriptBorrar);
            var resultsBorrado = psinstanceBorrado.Invoke();
        }

        private async Task<bool> createRunner(string key)
        {
            try
            {
                string pathOrigen = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER LineaTest";
                string pathDestino = @"C:\VSS-DB\Aplicaciones Sicer Testear\Training\SICER Linea TEST";

                string script = $"xcopy \"{pathOrigen}\" \"{pathDestino}\" /E /S /Y /D ";

                //PowerShellRunner ps = new PowerShellRunner();
                //ps.Key = key; 
                //ps.TextMessaje += runner_TextMessaje;
                //ps.ErrorMessaje += runner_TextMessaje;
                //ps.InfoMessaje += runner_TextMessaje;
                //ps.WarningMessaje += runner_TextMessaje;
                //ps.RunCommand(script);

                var r = await Task.Factory.StartNew<IPowerShellRunner>(() => new PowerShellRunner()).WaitAsync(CancellationToken.None);
                if (r != null)
                {
                    r.Key = key;
                    r.TextMessaje += runner_TextMessaje;
                    r.ErrorMessaje += runner_TextMessaje;
                    r.InfoMessaje += runner_TextMessaje;
                    r.WarningMessaje += runner_TextMessaje;
                    r.RunCommand(script);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.ToString()}");
            }

            return false;
        }

        private void runner_TextMessaje(IPowerShellRunner runner, string msg)
        {
            try
            {
                //txtPS.Text += msg + Environment.NewLine;
                txtPS.BeginInvoke(new Action(() => { txtPS.AppendText(msg + Environment.NewLine); }));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        #endregion
    }
}
