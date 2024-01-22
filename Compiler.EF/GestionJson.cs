using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Compiler.EF
{

    public interface IManagerJson
    {
        T cargarDatos<T>() where T : new();
        void GuardarDatos<T>(List<T> datos) where T : new();
    }

    public class ManagerJson : IManagerJson
    {
        private string getArchivoDatos(Type archivo)
        {
            string rutaBase = $"Data/{archivo.Name}.json";
            return rutaBase;
        }

        public T cargarDatos<T>() where T : new()
        {
            Type itemType = typeof(T);
            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                itemType = typeof(T).GetGenericArguments()[0];
            }
            string archivoDatos = getArchivoDatos(itemType);
            string pathArchivoDatos = Path.Combine(System.AppContext.BaseDirectory, archivoDatos);
            if (!Directory.Exists(Path.GetDirectoryName(pathArchivoDatos)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathArchivoDatos));
            }
            if (!File.Exists(pathArchivoDatos))
            {
                File.Create(pathArchivoDatos).Close();
            }
            using (StreamReader reader = new StreamReader(pathArchivoDatos))
            {
                var json = reader.ReadToEnd();
                T? usuariosAux = JsonConvert.DeserializeObject<T>(json);
                return usuariosAux ?? new T();
            }
        }

        public void GuardarDatos<T>(List<T> datos) where T : new()
        {
            string archivoDatos = getArchivoDatos(typeof(T));
            string pathArchivoDatos = Path.Combine(System.AppContext.BaseDirectory, archivoDatos);

            if (!Directory.Exists(Path.GetDirectoryName(pathArchivoDatos)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(pathArchivoDatos));
            }
            if (!File.Exists(pathArchivoDatos))
            {
                File.Create(pathArchivoDatos).Close();
            }
            using (StreamWriter writer = new StreamWriter(pathArchivoDatos))
            {
                var json = JsonConvert.SerializeObject(datos);
                writer.Write(json);
            }
        }
    }
}
