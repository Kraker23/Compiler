
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace Compiler.UI
{
    public partial class frmMain : MetroForm
    {
        public frmMain()
        {
            InitializeComponent();

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

        
    }
}
