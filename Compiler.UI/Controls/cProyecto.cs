using Compiler.Shared;
using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
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
    public partial class cProyecto : MetroUserControl
    {
        public delegate void GuardarEvento(Proyecto proyecto);
        public event GuardarEvento Guardar;

        IAplicacion_BL managerAplicacion;
        List<Aplicacion> aplicaciones;

        Proyecto proyecto;
        public cProyecto()
        {
            InitializeComponent();
            managerAplicacion = Inject.Instance.ServiceProvider.GetService<IAplicacion_BL>();
        }
        public void set(Proyecto proyecto)
        {
            this.proyecto = proyecto;
            LoadData();
        }

        private void cProyecto_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            aplicaciones = managerAplicacion.getAplicaciones();
            treeAplicaciones.Nodes.Clear();
            propId.Enabled = false;
            if (proyecto != null)
            {
                propId.text = proyecto.id.ToString();
                propNombre.text = proyecto.nombre;
            }
            foreach (Aplicacion aplicacion in aplicaciones)
            {
                TreeNode node = new TreeNode(aplicacion.nombre);
                node.Tag = aplicacion;
                node.Checked = proyecto != null && proyecto.aplicaciones.Contains(aplicacion.id);
                treeAplicaciones.Nodes.Add(node);
            }
        }

       

        private void btSave_Click(object sender, EventArgs e)
        {
            if (proyecto != null)
            {
                proyecto.nombre = propNombre.text;
            }
            Guardar?.Invoke(proyecto);
        }

        private void treeAplicaciones_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode nodo = ((TreeNode)e.Node);
            Aplicacion archivoExclusion = ((Aplicacion)nodo.Tag);
            if (proyecto.aplicaciones.Contains(archivoExclusion.id) && !nodo.Checked)
            {
                proyecto.aplicaciones.Remove(archivoExclusion.id);
            }
            else if (!proyecto.aplicaciones.Contains(archivoExclusion.id) && nodo.Checked)
            {
                proyecto.aplicaciones.Add(archivoExclusion.id);
            }
        }
    }
}
