using Compiler.Shared;
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Microsoft.Extensions.DependencyInjection;
using System.Management.Automation;
using Compiler.Shared.Extenders;
namespace Compiler.AppNotifyIcon
{
    public partial class frmNotify : Form
    {
        private ToolStripMenuItem mniVerPrograma;
        private ToolStripMenuItem mniCerrarPrograma;
        IProyecto_BL managerProyecto;
        IAplicacion_BL managerAplicacion;
        IArchivoExclusion_BL managerExclusion;
        IArchivosAdmitido_BL managerAdmitido;
        List<Proyecto> proyectos;
        readonly string nombreArchivosExlcudes = "excludedfileslist.txt";
        PowerShell ps;

        public frmNotify()
        {
            InitializeComponent();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();
            managerAdmitido = Inject.Instance.ServiceProvider.GetService<IArchivosAdmitido_BL>();
        }

        private void frmNotify_Load(object sender, EventArgs e)
        {
            proyectos = managerProyecto.getProyectos();
            CargarMenuContextual();
            VerPrograma();
        }

        public bool seVe = true;
        private bool cerrar = false;

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

        #region ToolStripMenu
        private void CargarMenuContextual()
        {
            this.cmBarraIconos.Items.Clear();
            ToolStripSeparator tsSeparatorAux = GenerarToolStripSeparator();

            GenerarToolStripMenuItemProyectos();
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

        private void GenerarToolStripMenuItemProyectos()
        {
            foreach (Proyecto proyecto in proyectos)
            {
                ToolStripMenuItem mniAuxiliar = new ToolStripMenuItem();
                mniAuxiliar.Name = "mniAuxiliar" + proyecto.nombre;
                mniAuxiliar.Size = new Size(180, 22);
                mniAuxiliar.Text = proyecto.nombre;
                mniAuxiliar.Image = Properties.Resources.folder_gear;
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
            mniCopiar.Image = Properties.Resources.scroll_run;
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
            mniCompilar.Image = Properties.Resources.scroll_run;
            mniCompilar.Click += new EventHandler(this.mniCompilar_Click);
            return mniCompilar;
        }

        private ToolStripMenuItem GenerarToolStripMenuItemCompilarCopiar(Proyecto proyecto)
        {
            ToolStripMenuItem mniCompilarCopiar = new ToolStripMenuItem();
            mniCompilarCopiar.Name = "mniCompilarCopiar" + proyecto.nombre;
            mniCompilarCopiar.Enabled = false;
            mniCompilarCopiar.Size = new Size(180, 22);
            mniCompilarCopiar.Text = $"Copiar y Compilar -> {proyecto.nombre}";
            mniCompilarCopiar.Tag = proyecto;
            mniCompilarCopiar.Image = Properties.Resources.scroll_run;
            mniCompilarCopiar.Click += new EventHandler(this.mniCompilarCopiar_Click);
            return mniCompilarCopiar;
        }
        #endregion

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



        #region Copiar y Compilar
        private void Copiar(Proyecto proyecto)
        {
            txtPS.Clear();
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

        #region EjecutarPS


        public async void EjecutarPS_Copiar(Aplicacion aplicacion)
        {
            crearArchivosExcluidos(aplicacion.archivosExcluidos);
            if (!Directory.Exists(aplicacion.carpetaCompilado))
            {
                Directory.CreateDirectory(aplicacion.carpetaCompilado);
            }
            if (!Directory.Exists(aplicacion.carpetaPublicacion))
            {
                Directory.CreateDirectory(aplicacion.carpetaPublicacion);
            }
            string script = $"xcopy \"{aplicacion.carpetaCompilado}\" \"{aplicacion.carpetaPublicacion}\" /E /Y /D /exclude:{nombreArchivosExlcudes}";

            txtPS.Text += $"-------------- COPIAR ------->>>> {aplicacion.nombre.ToUpper()}--------------  {Environment.NewLine} {Environment.NewLine}";
            txtPS.Text += $"{script}{Environment.NewLine} {Environment.NewLine}";

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += Progress_DataAdded;

            PowerShell psinstance = PowerShell.Create();
            psinstance.AddScript(script);

            //psinstance.BeginInvoke<PSObject, PSObject>(null, output);
            progresBar.Visible = seVe&& true;
            Task.Factory.StartNew<IAsyncResult>(() => psinstance.BeginInvoke<PSObject, PSObject>(null, output)).Wait();
            progresBar.Visible = false;
            MessageBox.Show($"Proceso de Copiado {aplicacion.nombre.ToUpper()} Terminado {Environment.NewLine} {script}");
        }

        private void Progress_DataAdded(object? sender, DataAddedEventArgs e)
        {
            if (seVe)
            {
                PSObject newRecord = ((PSDataCollection<PSObject>)sender)[e.Index];

                txtPS.BeginInvoke(new Action(() => { txtPS.AppendText($"[{e.Index}] {newRecord.BaseObject} {Environment.NewLine}"); }));
                progresBar.BeginInvoke(new Action(() =>
                {
                    progresBar.Visible = true;
                    progresBar.Value = progresBar.Value < 100 ? progresBar.Value + 1 : 0;
                }));
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


        public async void EjecutarPS_Cristian()
        {
            psBorrado();
            psExcludeArchivos();

            string pathOrigen = @"C:\VSS-DB\España\Sicer-España\Dnota.Central\DNOTA.Central.dlls";
            string pathDestino = @"C:\VSS-DB\España\Sicer Compilados\Sicer Compilados Develop\CENTRAL_CLIENTE_TEST";

            string script = $"xcopy \"{pathOrigen}\" \"{pathDestino}\" /E /Y /D /exclude:{nombreArchivosExlcudes}";
            txtPS.Text += script + Environment.NewLine + Environment.NewLine;

            PSDataCollection<PSObject> output = new PSDataCollection<PSObject>();
            output.DataAdded += Progress_DataAdded;

            PowerShell psinstance = PowerShell.Create();
            psinstance.AddScript(script);

            var r = await Task.Factory.StartNew<IAsyncResult>(() => psinstance.BeginInvoke<PSObject, PSObject>(null, output));
        }

        public void psBorrado()
        {
            string pathDestino = @"C:\VSS-DB\España\Sicer Compilados\Sicer Compilados Develop\CENTRAL_CLIENTE_TEST";
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

        #endregion


        #region Events

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
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


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            progresBar.Maximum = 600;

            progresBar.Visible = true;

            EjecutarPS_Cristian();
        }
    }
}
