using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Enums
{
    public static class Enumeraciones
    {
        public enum ImagenNodo
        {
            carpetaNueva = 0,
            carpetaModificada = 1,
            carpetaEliminar = 2,
            carpetaOK = 3,
            carpetaExcluido = 4,
            archivoNueva = 5,
            archivoModificada = 6,
            archivoEliminar = 7,
            archivoOK = 8,
            archivoExcluido = 9

        };

        public enum Accion
        {
            [Description("Compilar")]
            Compilar = 0,
            [Description("Copiar")]
            Copiar = 1,
            [Description("Compilar y Copiar")]
            CompilarCopiar = 2

        };

        public enum TipoExclusion
        {
            [Description("Extension del Archivo")]
            Extension = 0,
            [Description("Nombre del archivo/Carpeta")]
            Nombre = 1,
            [Description("Nombre completo del archivo")]
            NombreCompleto = 2,

        };


        public static int getId(this ImagenNodo imagenNodo)
        {
            // int valor = (int)imagenNodo.SI; //-> te devuelve el valor
            //string literal = imagenNodo.SI.ToString(); //-> te devuelve el literal
            return (int)imagenNodo;
        }
        public static string getString(this ImagenNodo imagenNodo)
        {
            // int valor = (int)imagenNodo.SI; //-> te devuelve el valor
            // string literal = imagenNodo.ToString(); //-> te devuelve el literal
            return imagenNodo.ToString();
        }
    }
}
