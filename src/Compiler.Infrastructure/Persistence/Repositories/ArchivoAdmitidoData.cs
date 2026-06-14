using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;
using Compiler.Infrastructure.Persistence.Json;

namespace Compiler.Infrastructure.Persistence.Repositories;

public class ArchivoAdmitidoData(IJsonDataManager managerJson) : IArchivoAdmitidoData
{
    private List<ArchivoAdmitido> archivoAdmitidos = [];

    public void CargarDatos()
    {
        try
        {
            archivoAdmitidos = managerJson.CargarDatos<List<ArchivoAdmitido>>();
        }
        catch
        {
            archivoAdmitidos = [];
        }
    }

    public ArchivoAdmitido Add(ArchivoAdmitido dato)
    {
        try
        {
            if (!archivoAdmitidos.Exists(x => x.id == dato.id))
            {
                archivoAdmitidos.Add(dato);
                SaveData();
            }

            return dato;
        }
        catch
        {
            return dato;
        }
    }

    public List<ArchivoAdmitido> GetAll()
    {
        try
        {
            CargarDatos();
            return archivoAdmitidos;
        }
        catch
        {
            return [];
        }
    }

    public ArchivoAdmitido? GetById(Guid id)
    {
        try
        {
            return archivoAdmitidos.FirstOrDefault(x => x.id == id);
        }
        catch
        {
            return null;
        }
    }

    public ArchivoAdmitido Update(ArchivoAdmitido dato)
    {
        try
        {
            var item = archivoAdmitidos.FirstOrDefault(x => x.id == dato.id);
            if (item == null)
            {
                return Add(dato);
            }

            item.id = dato.id;
            item.texto = dato.texto;
            item.tipoAdmision = dato.tipoAdmision;

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
            var item = archivoAdmitidos.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                archivoAdmitidos.Remove(item);
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
            managerJson.GuardarDatos(archivoAdmitidos);
        }
        catch
        {
        }
    }
}
