using Compiler.Shared.Extenders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compiler.Shared.Enums.Enumeraciones;

namespace Compiler.Shared.DataObjects
{
    public class ArchivoExclusion
    {
        /// <summary>Id de la Regla</summary>
        public Guid id { get; set; }
        /// <summary>Nombre de la Regla</summary>
        public string texto { get; set; }
        /// <summary>de que tipo es la regla</summary>
        public int tipoExclusion { get; set; }
        public ArchivoExclusion()
        {
            id = Guid.NewGuid();
            tipoExclusion = (int)TipoExclusion.Extension;
        }
        public override string ToString()
        {
            return $"[{Extenders.EnumExtensions.GetDescription((Enums.Enumeraciones.TipoExclusion)tipoExclusion)}] {texto}";
        }
    }
}
