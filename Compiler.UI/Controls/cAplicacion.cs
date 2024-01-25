using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Starter;
using MetroFramework.Controls;
using Microsoft.Extensions.DependencyInjection;
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
using static System.Net.Mime.MediaTypeNames;

namespace Compiler.UI.Controls
{
    public partial class cAplicacion : MetroUserControl
    {


        public delegate void GuardarEvento(Aplicacion aplicacion);
        public event GuardarEvento Guardar;
        IArchivoExclusion_BL managerExclusion;
        List<ArchivoExclusion> archivosExclusion;
        Aplicacion aplicacion;
        public cAplicacion()
        {
            InitializeComponent();
            managerExclusion = Inject.Instance.ServiceProvider.GetService<IArchivoExclusion_BL>();
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
            archivosExclusion = managerExclusion.getArchivoExclusiones();
            treeArchivos.Nodes.Clear();
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
            foreach (ArchivoExclusion archivo in archivosExclusion)
            {
                TreeNode node = new TreeNode(archivo.texto);
                node.Tag = archivo;
                node.Checked = aplicacion != null && aplicacion.archivosExcluidos.Contains(archivo.id);
                treeArchivos.Nodes.Add(node);
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

        private void btUbicacionAplicacion_Click(object sender, EventArgs e)
        {
            string[] path = BuscarArchivos.SeleccionarArchivo(true, multiSelect: false);
            if (path.HasContent() && path.Length == 1)
            {
                propUbicacionAplicacion.text = path[0];
            }
        }

        private void btCarpetaCompilado_Click(object sender, EventArgs e)
        {
            string rutaBase = string.Empty;
            if (!string.IsNullOrEmpty(propCarpetaCompilado.text) && Directory.Exists(propCarpetaCompilado.text))
            {
                rutaBase = propCarpetaCompilado.text;
            }
            string path = BuscarArchivos.SeleccionarCarpetaClassico(rutaBase);
            if (!string.IsNullOrEmpty(path))
            {
                propCarpetaCompilado.text = path;
            }
        }

        private void btCarpetaPublicacion_Click(object sender, EventArgs e)
        {
            string rutaBase = string.Empty;
            if (!string.IsNullOrEmpty(propCarpetaPublicacion.text) && Directory.Exists(propCarpetaPublicacion.text))
            {
                rutaBase = propCarpetaPublicacion.text;
            }
            string path = BuscarArchivos.SeleccionarCarpetaClassico(propCarpetaPublicacion.text);
            if (!string.IsNullOrEmpty(path))
            {
                propCarpetaPublicacion.text = path;
            }
        }

        private void treeArchivos_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode nodo = ((TreeNode)e.Node);
            ArchivoExclusion archivoExclusion = ((ArchivoExclusion)nodo.Tag);
            if (aplicacion.archivosExcluidos.Contains(archivoExclusion.id) && !nodo.Checked)
            {
                aplicacion.archivosExcluidos.Remove(archivoExclusion.id);
            }
            else if (!aplicacion.archivosExcluidos.Contains(archivoExclusion.id) && nodo.Checked)
            {
                aplicacion.archivosExcluidos.Add(archivoExclusion.id);
            }
        }

        private void btValidarCarpetaPublicacion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(propCarpetaCompilado.text) 
                || !Directory.Exists(propCarpetaCompilado.text))
            {
                MessageBox.Show("No existe la ruta");
            }
        }

        private void btValidarCarpetaCompilado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(propCarpetaPublicacion.text) 
                || !Directory.Exists(propCarpetaPublicacion.text))
            {
                MessageBox.Show("No existe la ruta");
            }
        }
    }
}
