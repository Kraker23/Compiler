using Compiler.Shared.DataObjects;
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
using static System.Net.Mime.MediaTypeNames;

namespace Compiler.UI.Controls
{
    public partial class cAplicacion : MetroUserControl
    {


        public delegate void GuardarEvento(Aplicacion aplicacion);
        public event GuardarEvento Guardar;

        Aplicacion aplicacion;
        public cAplicacion()
        {
            InitializeComponent();
        }

        public cAplicacion(Aplicacion aplicacion)
        {
            InitializeComponent();
            this.aplicacion = aplicacion;
        }

        public void set(Aplicacion aplicacion)
        {
            this.aplicacion = aplicacion;
            LoadData();
        }

        private void cAplicacion_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            propId.Enabled = false;
            if (aplicacion != null)
            {
                propId.text = aplicacion.id.ToString();
                propNombre.text = aplicacion.nombre;
                propUbicacionAplicacion.text = aplicacion.ubicacionAplicacion;
                propCarpetaCompilado.text = aplicacion.carpetaCompilado;
                propCarpetaPublicacion.text = aplicacion.carpetaPublicacion;
                propComandoCompilado.text = aplicacion.comandoCompilado;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (aplicacion != null)
            {
                aplicacion.nombre = propNombre.text;
                aplicacion.ubicacionAplicacion = propUbicacionAplicacion.text;
                aplicacion.carpetaCompilado = propCarpetaCompilado.text;
                aplicacion.carpetaPublicacion = propCarpetaPublicacion.text;
                aplicacion.comandoCompilado = propComandoCompilado.text;
            }
            Guardar?.Invoke(aplicacion);
        }
    }
}
