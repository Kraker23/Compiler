using Compiler.Domain.Extenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Compiler.Domain.Enums.Enumeraciones;

namespace Compiler.Domain.Entities
{
    public class Carpeta
    {
        /// <summary>Id de la Regla</summary>
        public Guid id { get; set; }
        [JsonIgnore]
        public string idString { get { return id.ToString(); } }
        /// <summary>Nombre de la Carpeta</summary>
        public string nombre { get; set; } = string.Empty;
        public Carpeta()
        {
            id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return $"{nombre}";
        }
    }
}


