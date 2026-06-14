using Newtonsoft.Json;

namespace Compiler.Infrastructure.Persistence.Json;

public class JsonDataManager : IJsonDataManager
{
    private static string GetArchivoDatos(Type archivo)
    {
        return Path.Combine("Data", $"{archivo.Name}.json");
    }

    public T CargarDatos<T>() where T : new()
    {
        Type itemType = typeof(T);
        if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
        {
            itemType = typeof(T).GetGenericArguments()[0];
        }

        string archivoDatos = GetArchivoDatos(itemType);
        string pathArchivoDatos = Path.Combine(AppContext.BaseDirectory, archivoDatos);
        string? directorio = Path.GetDirectoryName(pathArchivoDatos);

        if (!string.IsNullOrWhiteSpace(directorio) && !Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        if (!File.Exists(pathArchivoDatos))
        {
            File.Create(pathArchivoDatos).Close();
            return new T();
        }

        using var reader = new StreamReader(pathArchivoDatos);
        var json = reader.ReadToEnd();
        var settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        T? aux = JsonConvert.DeserializeObject<T>(json, settings);
        return aux ?? new T();
    }

    public void GuardarDatos<T>(List<T> datos) where T : new()
    {
        string archivoDatos = GetArchivoDatos(typeof(T));
        string pathArchivoDatos = Path.Combine(AppContext.BaseDirectory, archivoDatos);
        string? directorio = Path.GetDirectoryName(pathArchivoDatos);

        if (!string.IsNullOrWhiteSpace(directorio) && !Directory.Exists(directorio))
        {
            Directory.CreateDirectory(directorio);
        }

        if (!File.Exists(pathArchivoDatos))
        {
            File.Create(pathArchivoDatos).Close();
        }

        using var writer = new StreamWriter(pathArchivoDatos);
        var json = JsonConvert.SerializeObject(datos);
        writer.Write(json);
    }
}
