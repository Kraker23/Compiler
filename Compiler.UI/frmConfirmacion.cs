using MetroFramework.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Compiler.UI
{
    public partial class frmConfirmacion : MetroForm
    {
        public frmConfirmacion(string titulo, string informacion)
        {
            InitializeComponent();
            this.Text = titulo;
            this.lblInformacion.Text = informacion;
        }
        public frmConfirmacion(string titulo, string informacion, bool guardado)
        {
            InitializeComponent();
            
            this.Text = titulo;
            this.lblInformacion.Text = informacion;
            this.btOk.Text = "Guardar";
            this.btCancel.Text = "Cancelar";
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

        }

       
    }
}
