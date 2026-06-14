using Compiler.Shared.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared
{
    public static class Functions
    {
        public static string GetPattern(Aplicacion aplicacion)
        {
            return GetPattern(aplicacion._archivosAdmitidos, aplicacion._archivosExcluidos);
        }
        public static string GetPattern(List<ArchivoAdmitido> admitidos, List<ArchivoExclusion> excluidos)
        {
            List<string> result = new List<string>();
            string pattern, patternExtension, patternNombre, patternNombreCompleto;
            pattern = patternExtension = patternNombre = patternNombreCompleto = string.Empty;
            if (admitidos != null && admitidos.Count() > 0)
            {
                List<string> extensiones = admitidos.Where(x => x.tipoAdmision == (int)Enums.Enumeraciones.TipoExclusionAdmision.Extension).Select(x => x.texto).ToList();
                List<string> nombres = admitidos.Where(x => x.tipoAdmision == (int)Enums.Enumeraciones.TipoExclusionAdmision.Nombre).Select(x => x.texto).ToList();
                List<string> nombresCompletos = admitidos.Where(x => x.tipoAdmision == (int)Enums.Enumeraciones.TipoExclusionAdmision.NombreCompleto).Select(x => x.texto).ToList();


                patternExtension = String.Join("|", extensiones.ToArray());
                patternNombre = String.Join("|", nombres.ToArray());
                patternNombreCompleto = String.Join("|", nombresCompletos.ToArray()).Replace(".", "\\.");

                if (!string.IsNullOrEmpty(patternExtension)) patternExtension = $"(\\.({patternExtension})$)";
                if (!string.IsNullOrEmpty(patternNombre)) patternNombre = $"(({patternNombre})\\.(?:.*))"; 
                if (!string.IsNullOrEmpty(patternNombreCompleto)) patternNombreCompleto = $"(({patternNombreCompleto})$)";

                pattern = string.Join("|", patternExtension, patternNombre, patternNombreCompleto);


                ///Falta poner las exclusiones en los mismos patterns
            }



            return string.IsNullOrEmpty(pattern) ? "*" : pattern;
        }
    }
}
