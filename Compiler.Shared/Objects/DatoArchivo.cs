using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compiler.Shared.Enums.Enumeraciones;

namespace Compiler.Shared.Objects
{

    public class DatoArchivo
    {
        public string Hash { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Url { get; set; }
        public int Level { get; set; }
        public bool Archivo { get; set; }
        public string rutaBase { get; set; }
        public string rutaSinBase { get; set; }
        public string rutaExtremo
        {
            get
            {
                string resultado = string.Empty;
                resultado = Url.Replace(Nombre, "").Substring(0, Url.Replace(Nombre, "").Length - 1);
                return resultado;
            }
        }
        public bool SoloLectura { get; set; }
        public bool Modificado { get; set; }
        public bool Excluido { get; set; }
        public ImagenNodo imagenNodo { get; set; }

        public override string ToString()
        {
            string archivo = Archivo ? "1" : "0";
            string lectura = SoloLectura ? "1" : "0";
            return Nombre + "[" + Fecha.ToShortDateString() + "]" + "{" + archivo + "}" + "--->" + lectura;
        }

        public bool IsFileReadOnly(string FileName)
        {
            // Create a new FileInfo object.
            FileInfo fInfo = new FileInfo(FileName);

            // Return the IsReadOnly property value.
            return fInfo.IsReadOnly;

        }

    }
}
