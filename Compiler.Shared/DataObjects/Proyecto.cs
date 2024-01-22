using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.DataObjects
{
    public class Proyecto
    {
        /// <summary>Id del proyecto</summary>
        public Guid id { get; set; }
        /// <summary>Nombre del proyecto</summary>
        public string nombre { get; set; }
        /// <summary>Listado de Aplicaciones que afectan  al proyecto</summary>
        public List<Aplicacion> aplicaciones { get; set; }
        public Proyecto()
        {
            id = Guid.NewGuid();
            aplicaciones = new List<Aplicacion>();
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
