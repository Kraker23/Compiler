using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Extenders
{

    /// <summary>
    /// Extensiones para <ver cref="Enum" />.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Parsear un valor de enumeración de un tipo dado de una cadena.
        /// </summary>
        public static TEnum ParseEnum<TEnum>(this string valor, bool ignorarCaseSensitive = true) where TEnum : struct, Enum
        {
            return (TEnum)Enum.Parse(typeof(TEnum), valor, ignorarCaseSensitive);
        }



        public static int GetValor<T>(this T t) where T : struct
        {
            var tipo = typeof(T);
            if (!tipo.IsEnum)
                return default(int);
            try
            {
                return (int)(object)t;
            }
            catch
            {
                return default(int);
            }
        }

        public static string GetTexto<T>(this T tp) where T : struct
        {
            try
            {
                var tipo = tp.GetType();
                if (!tipo.IsEnum)
                    return "Error de tipo de enumeración";
                var campos = tipo.GetFields().FirstOrDefault(t => t.Name == tp + "");
                if (campos != null)
                {
                    var descripcion = campos.GetCustomAttributes(true).FirstOrDefault(t => (t as DescriptionAttribute) != null);
                    if (descripcion != null)
                        return ((DescriptionAttribute)descripcion).Description;
                    return campos.Name;
                }
                return "Error de enumeración";
            }
            catch
            {
                return "Excepción de enumeración";
            }
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }
    }
}
