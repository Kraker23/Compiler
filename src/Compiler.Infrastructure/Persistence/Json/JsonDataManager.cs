using Newtonsoft.Json;

namespace Compiler.Infrastructure.Persistence.Json;

public class JsonDataManager : IJsonDataManager
{
    public JsonDataManager()
    {
    }

    private string GetPathArchivoDatos(Type archivo)
    {
        var dataDirectory = string.IsNullOrWhiteSpace(JsonStorageContext.DataDirectory) ? "Data" : JsonStorageContext.DataDirectory;
        return Path.Combine(AppContext.BaseDirectory, dataDirectory, $"{archivo.Name}.json");
    }

    public T CargarDatos<T>() where T : new()
    {
        Type itemType = typeof(T);
        if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
        {
            itemType = typeof(T).GetGenericArguments()[0];
        }

        string pathArchivoDatos = GetPathArchivoDatos(itemType);
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
        string pathArchivoDatos = GetPathArchivoDatos(typeof(T));
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
