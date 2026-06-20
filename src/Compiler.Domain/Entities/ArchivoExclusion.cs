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
    public class ArchivoExclusion
    {
        /// <summary>Id de la Regla</summary>
        public Guid id { get; set; }
        [JsonIgnore]
        public string idString { get { return id.ToString(); } }
        /// <summary>Nombre de la Regla</summary>
        public string texto { get; set; } = string.Empty;
        /// <summary>de que tipo es la regla</summary>
        public int tipoExclusion { get; set; }
        public ArchivoExclusion()
        {
            id = Guid.NewGuid();
            tipoExclusion = (int)TipoExclusionAdmision.Extension;
        }
        public override string ToString()
        {
            return $"[{Extenders.EnumExtensions.GetDescription((Enums.Enumeraciones.TipoExclusionAdmision)tipoExclusion)}] {texto}";
        }
    }
}


