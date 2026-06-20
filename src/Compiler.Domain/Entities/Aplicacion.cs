using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Compiler.Domain.Entities
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
        public string nombre { get; set; } = string.Empty;
        /// <summary>Ubicacion de la aplicacion (csproj o sln)</summary>
        public string ubicacionAplicacion { get; set; } = string.Empty;
        /// <summary>Ubicacion donde se encuentra el compilado</summary>
        public string carpetaCompilado { get; set; } = string.Empty;
        /// <summary> Ruta Destino a donde se Copiara </summary>
        public string carpetaPublicacion { get; set; } = string.Empty;
        /// <summary> el comando que se usara para compilar </summary>
        public string comandoCompilado { get; set; } = string.Empty;

        /// <summary>Listado de Reglas para copiar</summary>
        public List<Guid> archivosExcluidos { get; set; } = new List<Guid>();
        [JsonIgnore]
        public List<ArchivoExclusion> _archivosExcluidos { get; set; } = new List<ArchivoExclusion>();


        /// <summary>Listado de Reglas para copiar</summary>
        public List<Guid> archivosAdmitidos { get; set; } = new List<Guid>();
        [JsonIgnore]
        public List<ArchivoAdmitido> _archivosAdmitidos { get; set; } = new List<ArchivoAdmitido>();
        [JsonIgnore]
        public bool isNew { get; set; } = false;

        public Aplicacion()
        {
            InicializarListas();
        }

        public Aplicacion(bool isNew = false)
        {
            InicializarListas();
            this.isNew = isNew;
        }

        private void InicializarListas()
        {
            id = Guid.NewGuid();
            if (archivosExcluidos == null)
                archivosExcluidos = new List<Guid>();
            if (archivosAdmitidos == null)
                archivosAdmitidos = new List<Guid>();
        }

        public Aplicacion(Aplicacion aplicacionAux)
        {
            InicializarListas();
            fk_IdCarpeta = aplicacionAux.fk_IdCarpeta;
            nombre = aplicacionAux.nombre;
            ubicacionAplicacion = aplicacionAux.ubicacionAplicacion;
            carpetaCompilado = aplicacionAux.carpetaCompilado;
            carpetaPublicacion = aplicacionAux.carpetaPublicacion;
            comandoCompilado = aplicacionAux.comandoCompilado;
            archivosExcluidos = aplicacionAux.archivosExcluidos;
            archivosAdmitidos = aplicacionAux.archivosAdmitidos;
        }


        public override string ToString()
        {
            return nombre;
        }
    }
}


