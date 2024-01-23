using Compiler.Shared.DataObjects;
using Compiler.Shared.Enums;
using Compiler.Shared.Extenders;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Clases.BuscarFicheros;
using Utilities.Extensions;
using static Compiler.Shared.Enums.Enumeraciones;
using static System.Net.Mime.MediaTypeNames;

namespace Compiler.UI.Controls
{
    public partial class cArchivoExclusion : MetroUserControl
    {


        public delegate void GuardarEvento(ArchivoExclusion archivo);
        public event GuardarEvento Guardar;
        List<EnumBase> estados;
        ArchivoExclusion archivo;
        public cArchivoExclusion()
        {
            InitializeComponent();
        }

        public void set(ArchivoExclusion aplicacion)
        {
            this.archivo = aplicacion;
            LoadData();
        }

        private void cArchivoExclusion_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            generarCboTipoExlusion();

            propId.Enabled = false;
            if (archivo != null)
            {
                propId.text = archivo.id.ToString();
                propContenido.text = archivo.texto;

                cboTipoExclusion.SelectedIndex = cboTipoExclusion.Items.IndexOf(
                    estados.First (x=>x.Id== archivo.tipoExclusion));
            }
        }

        private void generarCboTipoExlusion()
        {
            cboTipoExclusion.Items.Clear();

            estados = getListTipoExclusion();
            cboTipoExclusion.DisplayMember = "Text";
            cboTipoExclusion.ValueMember = "Value";
            foreach (EnumBase estado in estados)
            {                
                cboTipoExclusion.Items.Add(estado);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (archivo != null)
            {
                archivo.texto = propContenido.text;
                archivo.tipoExclusion = ((EnumBase)cboTipoExclusion.SelectedItem).Id;
            }
            Guardar?.Invoke(archivo);
        }

        private void btArchivoConcreto_Click(object sender, EventArgs e)
        {
            string[] path = BuscarArchivos.SeleccionarArchivo(false,multiSelect:false);
            if (path.HasContent() && path.Length==1)
            {
                propContenido.text = path[0];
                cboTipoExclusion.SelectedIndex = cboTipoExclusion.Items.IndexOf(
                    estados.First(x => x.Id == (int)TipoExclusion.NombreCompleto));
            }
        }

        private void cboTipoExclusion_SelectedIndexChanged(object sender, EventArgs e)
        {
            archivo.tipoExclusion =  ((EnumBase)cboTipoExclusion.SelectedItem).Id;
        }


    }
}
