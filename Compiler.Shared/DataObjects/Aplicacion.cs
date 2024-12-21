using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Compiler.Shared.DataObjects
{
    public class Aplicacion
    {
        /// <summary>Id de la Aplicacion</summary>
        public Guid id { get; set; }
        [JsonIgnore]
        public string idString { get { return id.ToString(); } }
        /// <summary>IdCarpeta</summary>
        public Guid? fk_IdCarpeta { get; set; }
        /// <summary>Nombre de la Aplicacion</summary>
        public string nombre { get; set; }
        /// <summary>Ubicacion de la aplicacion (csproj o sln)</summary>
        public string ubicacionAplicacion { get; set; }
        /// <summary>Ubicacion donde se encuentra el compilado</summary>
        public string carpetaCompilado { get; set; }
        /// <summary> Ruta Destino a donde se Copiara </summary>
        public string carpetaPublicacion { get; set; }
        /// <summary> el comando que se usara para compilar </summary>
        public string comandoCompilado { get; set; }
        
        /// <summary>Listado de Reglas para copiar</summary>
        public List<Guid> archivosExcluidos { get; set; }
        [JsonIgnore]
        public List<ArchivoExclusion> _archivosExcluidos { get; set; }
        public Aplicacion()
        {
            id = Guid.NewGuid();
            archivosExcluidos = new List<Guid>();
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
