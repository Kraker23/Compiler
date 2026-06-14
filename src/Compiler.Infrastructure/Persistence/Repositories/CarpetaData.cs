using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;
using Compiler.Infrastructure.Persistence.Json;

namespace Compiler.Infrastructure.Persistence.Repositories;

public class CarpetaData(IJsonDataManager managerJson) : ICarpetaData
{
    private List<Carpeta> carpetas = [];

    public void CargarDatos()
    {
        try
        {
            carpetas = managerJson.CargarDatos<List<Carpeta>>();
        }
        catch
        {
            carpetas = [];
        }
    }

    public Carpeta Add(Carpeta dato)
    {
        try
        {
            if (!carpetas.Exists(x => x.id == dato.id))
            {
                carpetas.Add(dato);
                SaveData();
            }

            return dato;
        }
        catch
        {
            return dato;
        }
    }

    public List<Carpeta> GetAll()
    {
        try
        {
            CargarDatos();
            return carpetas;
        }
        catch
        {
            return [];
        }
    }

    public Carpeta? GetById(Guid id)
    {
        try
        {
            return carpetas.FirstOrDefault(x => x.id == id);
        }
        catch
        {
            return null;
        }
    }

    public Carpeta Update(Carpeta dato)
    {
        try
        {
            var item = carpetas.FirstOrDefault(x => x.id == dato.id);
            if (item == null)
            {
                return Add(dato);
            }

            item.id = dato.id;
            item.nombre = dato.nombre;

            SaveData();
            return item;
        }
        catch
        {
            return dato;
        }
    }

    public void Delete(Guid id)
    {
        try
        {
            var item = carpetas.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                carpetas.Remove(item);
                SaveData();
            }
        }
        catch
        {
        }
    }

    public void SaveData()
    {
        try
        {
            managerJson.GuardarDatos(carpetas);
        }
        catch
        {
        }
    }
}
