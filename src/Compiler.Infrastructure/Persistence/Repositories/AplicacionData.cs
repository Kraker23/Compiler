using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;
using Compiler.Infrastructure.Persistence.Json;

namespace Compiler.Infrastructure.Persistence.Repositories;

public class AplicacionData(IJsonDataManager managerJson) : IAplicacionData
{
    private List<Aplicacion> aplicaciones = [];

    public void CargarDatos()
    {
        try
        {
            aplicaciones = managerJson.CargarDatos<List<Aplicacion>>();
        }
        catch
        {
            aplicaciones = [];
        }
    }

    public Aplicacion Add(Aplicacion dato)
    {
        try
        {
            if (!aplicaciones.Exists(x => x.id == dato.id))
            {
                aplicaciones.Add(dato);
                SaveData();
            }

            return dato;
        }
        catch
        {
            return dato;
        }
    }

    public List<Aplicacion> GetAll()
    {
        try
        {
            CargarDatos();
            return aplicaciones;
        }
        catch
        {
            return [];
        }
    }

    public Aplicacion? GetById(Guid id)
    {
        try
        {
            return aplicaciones.FirstOrDefault(x => x.id == id);
        }
        catch
        {
            return null;
        }
    }

    public Aplicacion Update(Aplicacion dato)
    {
        try
        {
            var item = aplicaciones.FirstOrDefault(x => x.id == dato.id);
            if (item == null)
            {
                return Add(dato);
            }

            item.id = dato.id;
            item.fk_IdCarpeta = dato.fk_IdCarpeta;
            item.nombre = dato.nombre;
            item.ubicacionAplicacion = dato.ubicacionAplicacion;
            item.carpetaCompilado = dato.carpetaCompilado;
            item.carpetaPublicacion = dato.carpetaPublicacion;
            item.comandoCompilado = dato.comandoCompilado;
            item.archivosExcluidos = dato.archivosExcluidos;
            item.archivosAdmitidos = dato.archivosAdmitidos;

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
            var item = aplicaciones.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                aplicaciones.Remove(item);
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
            managerJson.GuardarDatos(aplicaciones);
        }
        catch
        {
        }
    }
}
