using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;
using Compiler.Infrastructure.Persistence.Json;

namespace Compiler.Infrastructure.Persistence.Repositories;

public class ProyectoData(IJsonDataManager managerJson) : IProyectoData
{
    private List<Proyecto> proyectos = [];

    public void CargarDatos()
    {
        try
        {
            proyectos = managerJson.CargarDatos<List<Proyecto>>();
        }
        catch
        {
            proyectos = [];
        }
    }

    public Proyecto Add(Proyecto dato)
    {
        try
        {
            if (!proyectos.Exists(x => x.id == dato.id))
            {
                proyectos.Add(dato);
                SaveData();
            }

            return dato;
        }
        catch
        {
            return dato;
        }
    }

    public List<Proyecto> GetAll()
    {
        try
        {
            CargarDatos();
            return proyectos;
        }
        catch
        {
            return [];
        }
    }

    public Proyecto? GetById(Guid id)
    {
        try
        {
            return proyectos.FirstOrDefault(x => x.id == id);
        }
        catch
        {
            return null;
        }
    }

    public Proyecto Update(Proyecto dato)
    {
        try
        {
            var item = proyectos.FirstOrDefault(x => x.id == dato.id);
            if (item == null)
            {
                return Add(dato);
            }

            item.id = dato.id;
            item.nombre = dato.nombre;
            item.aplicaciones = dato.aplicaciones;

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
            var item = proyectos.FirstOrDefault(x => x.id == id);
            if (item != null)
            {
                proyectos.Remove(item);
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
            managerJson.GuardarDatos(proyectos);
        }
        catch
        {
        }
    }
}
