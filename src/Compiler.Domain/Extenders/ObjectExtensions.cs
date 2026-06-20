using Compiler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Compiler.Domain.Enums.Enumeraciones;

namespace Compiler.Domain.Extenders
{
    public static class ObjectExtensions
    {
        public static bool isEqualTo<T>(this T val1, T val2)
        {
            if (ReferenceEquals(val1, val2))
            {
                return true;
            }

            if (val1 is null || val2 is null)
            {
                return false;
            }

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
            if (a is null || b is null)
            {
                return false;
            }

            var tipoA = typeof(T);
            var tipoB = typeof(T2);
            var props = tipoA.GetProperties().FindAllToList(x => tipoB.GetProperties().Any(y => y.Name == x.Name && y.PropertyType == x.PropertyType));
            foreach (var p in props)
            {
                var propA = tipoA.GetProperty(p.Name);
                var propB = tipoB.GetProperty(p.Name);
                if (propA == null || propB == null)
                {
                    return false;
                }

                var valA = propA.GetValue(a);
                var valB = propB.GetValue(b);
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
                if (x.tipoExclusion == (int)TipoExclusionAdmision.Extension)
                {
                    resultado += $".{x.texto}{Environment.NewLine}";
                }
                else if (x.tipoExclusion == (int)TipoExclusionAdmision.Nombre
                || x.tipoExclusion == (int)TipoExclusionAdmision.NombreCompleto)
                {
                    resultado += $"{x.texto}{Environment.NewLine}";
                }
            });

            return resultado;
        }
    }
}

