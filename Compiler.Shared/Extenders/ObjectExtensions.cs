using Compiler.Shared.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Compiler.Shared.Enums.Enumeraciones;

namespace Compiler.Shared.Extenders
{
    public static class ObjectExtensions
    {
        public static bool isEqualTo<T>(this T val1, T val2)
        {
            PropertyInfo[] propertyInfos = val1.GetType().GetProperties();
            foreach (PropertyInfo p in propertyInfos)
            {
                var Prop = p.Name;
                var valA = p.GetValue(val1);
                var valB = p.GetValue(val2);
                if (valA != valB)
                    return false;
            }
            return true;
        }

        public static bool CompareObjects<T, T2>(T a, T2 b)
        {
            bool res = true;
            var tipoA = typeof(T);
            var tipoB = typeof(T2);
            var props = tipoA.GetProperties().FindAllToList(x => tipoB.GetProperties().Any(y => y.Name == x.Name && y.PropertyType == x.PropertyType));
            foreach (var p in props)
            {
                var valA = tipoA.GetProperty(p.Name).GetValue(a);
                var valB = tipoB.GetProperty(p.Name).GetValue(b);
                if (valA == null && valB == null)
                {
                    res = true;
                }
                else if (valA != null && valB != null)
                {
                    res = valA.Equals(valB);// (valA == valB);
                    if (!res)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            return res;
        }

        public static List<T> FindAllToList<T>(this T[] array, Predicate<T> match)
        {
            return Array.FindAll(array, match).ToList<T>();
        }

        public static string getArchivosToString(this List<ArchivoExclusion> archivoExclusions)
        {
            string resultado = string.Empty;
            archivoExclusions.ForEach(x =>
            {
                if (x.tipoExclusion == (int)TipoExclusion.Extension)
                {
                    resultado += $".{x.texto}{Environment.NewLine}";
                }
                else if (x.tipoExclusion == (int)TipoExclusion.NombreCompleto
                || x.tipoExclusion == (int)TipoExclusion.NombreCompleto)
                {
                    resultado += $"{x.texto}{Environment.NewLine}";
                }
            });

            return resultado;
        }
    }
}
