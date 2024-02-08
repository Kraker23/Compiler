using Compiler.Shared.Extenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compiler.Shared.Enums.Enumeraciones;

namespace Compiler.Shared.DataObjects
{
    public class Carpeta
    {
        /// <summary>Id de la Regla</summary>
        public Guid id { get; set; }
        /// <summary>Nombre de la Carpeta</summary>
        public string nombre { get; set; }
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
