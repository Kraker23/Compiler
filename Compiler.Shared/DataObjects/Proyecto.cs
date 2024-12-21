using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Compiler.Shared.DataObjects
{
    public class Proyecto
    {
        /// <summary>Id del proyecto</summary>
        public Guid id { get; set; }
        [JsonIgnore]
        public string idString { get { return id.ToString(); } }
        /// <summary>Nombre del proyecto</summary>
        public string nombre { get; set; }
        /// <summary>Listado de Aplicaciones que afectan  al proyecto</summary>
        public List<Guid> aplicaciones { get; set; }
        /// <summary>Listado de Aplicaciones que afectan  al proyecto</summary>
        [JsonIgnore]
        public List<Aplicacion> _aplicaciones { get; set; }
        public Proyecto()
        {
            id = Guid.NewGuid();
            aplicaciones = new List<Guid>();
        }
        public override string ToString()
        {
            return nombre;
        }
    }
}
