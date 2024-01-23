
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Starter;
using MetroFramework.Controls;
using MetroFramework.Forms;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Utilities.Clases.UtilidadesInterfaz;

namespace Compiler.UI
{
    public partial class frmMain : MetroForm
    {
        public bool seVe = true;
        private bool cerrar = false;
        private ToolStripMenuItem mniVerPrograma;
        private ToolStripMenuItem mniCerrarPrograma;

        IProyecto_BL managerProyecto;
        List<Proyecto> proyectos;
        public frmMain()
        {
            InitializeComponent();
            managerProyecto = Inject.Instance.ServiceProvider.GetService<IProyecto_BL>();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            CargarMenuContextual();
            VerPrograma();
        }

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

        private void tsCompilador_Click(object sender, EventArgs e)
        {
            Form frm = null;
            frm = GetFormularios(typeof(frmCompilador)).FirstOrDefault();
            if (frm == null)
            {
                frm = new frmCompilador();
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
            ToolStripSeparator tsSeparatorAux = GenerarToolStripSeparator();
            proyectos = managerProyecto.getProyectos();
            GenerarToolStripMenuItem();
            //foreach (Proyecto proyecto in proyectos)
            //{
            //    ToolStripMenuItem mniAuxiliar = GenerarToolStripMenuItem(proyecto);
            //    this.cmBarraIconos.Items.Add(mniAuxiliar);
            //}
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
        private ToolStripMenuItem GenerarToolStripMenuItem(Proyecto proyecto)
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

            mniAuxiliar.Click += new EventHandler(this.mniAuxiliar_Click);
            return mniAuxiliar;
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

                mniAuxiliar.Click += new EventHandler(this.mniAuxiliar_Click);
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
            mniCompilar.Size = new Size(180, 22);
            mniCompilar.Text = $"Compilar -> {proyecto.nombre}";
            mniCompilar.Tag = proyecto;
            mniCompilar.Click += new EventHandler(this.mniCompilar_Click);
            return mniCompilar;
        }

        private void mniAuxiliar_Click(object sender, EventArgs e)
        {
            //TODO
        }
        private void mniCopiar_Click(object sender, EventArgs e)
        {
            //TODO
        }
        private void mniCompilar_Click(object sender, EventArgs e)
        {
            //TODO
        }
    }
}
