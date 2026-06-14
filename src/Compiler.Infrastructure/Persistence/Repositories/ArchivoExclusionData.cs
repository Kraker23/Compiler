using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;
using Compiler.Infrastructure.Persistence.Json;

namespace Compiler.Infrastructure.Persistence.Repositories;

public class ArchivoExclusionData(IJsonDataManager managerJson) : IArchivoExclusionData
{
    private List<ArchivoExclusion> archivoExclusions = [];

    public void CargarDatos()
    {
        try
        {
            archivoExclusions = managerJson.CargarDatos<List<ArchivoExclusion>>();
        }
        catch
        {
            archivoExclusions = [];
        }
    }

    public ArchivoExclusion Add(ArchivoExclusion dato)
    {
        try
        {
            if (!archivoExclusions.Exists(x => x.id == dato.id))
            {
                archivoExclusions.Add(dato);
                SaveData();
            }

            return dato;
        }
        catch
        {
            return dato;
        }
    }

    public List<ArchivoExclusion> GetAll()
    {
        try
        {
            CargarDatos();
            return archivoExclusions;
        }
        catch
        {
            return [];
        }
    }

    public ArchivoExclusion? GetById(Guid id)
    {
        try
        {
            return archivoExclusions.FirstOrDefault(x => x.id == id);
        }
        catch
        {
            return null;
        }
    }

    public ArchivoExclusion Update(ArchivoExclusion dato)
    {
        try
        {
            var item = archivoExclusions.FirstOrDefault(x => x.id == dato.id);
            if (item == null)
            {
                return Add(dato);
            }

            item.id = dato.id;
            item.texto = dato.texto;
            item.tipoExclusion = dato.tipoExclusion;

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
            var item = archivoExclusions.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                archivoExclusions.Remove(item);
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
            managerJson.GuardarDatos(archivoExclusions);
        }
        catch
        {
        }
    }
}
