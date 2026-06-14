namespace Compiler.Infrastructure.Persistence.Json;

public interface IJsonDataManager
{
    T CargarDatos<T>() where T : new();
    void GuardarDatos<T>(List<T> datos) where T : new();
}
