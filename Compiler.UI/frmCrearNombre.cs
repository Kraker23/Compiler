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
    public partial class frmCrearNombre : MetroForm
    {
        public string resultado
        {
            get { return propNombre.text; }
        }

        public frmCrearNombre()
        {
            InitializeComponent();
            propNombre.Focus();
        }
        public frmCrearNombre(string valorLabel ):this()
        {
            if (string.IsNullOrEmpty(valorLabel))
            {
                valorLabel = "Nombre Carpeta";
            }
            propNombre.label = valorLabel;
        }

        public frmCrearNombre(string valorLabel,string nombreActual) : this(valorLabel)
        {
            propNombre.text = nombreActual;
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
