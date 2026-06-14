using Compiler.Application.Contracts.Data;
using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;

namespace Compiler.Application.Services;

public class ProyectoService(IProyectoData data) : IProyectoService
{
    public bool AnyProyectoConAplicacion(Guid idAplicacion)
    {
        return data.GetAll().Any(x => x.aplicaciones != null && x.aplicaciones.Exists(y => y == idAplicacion));
    }

    public void BorrarProyecto(Guid idProyecto)
    {
        try
        {
            data.Delete(idProyecto);
        }
        catch
        {
        }
    }

    public Proyecto? CrearProyecto(Proyecto proyecto)
    {
        try
        {
            return data.Add(proyecto);
        }
        catch
        {
            return null;
        }
    }

    public bool ExisteProyecto(Guid idProyecto)
    {
        return data.GetById(idProyecto) != null;
    }

    public Proyecto? GetProyecto(Guid idProyecto)
    {
        return data.GetById(idProyecto);
    }

    public List<Proyecto> GetProyectos()
    {
        return data.GetAll().OrderBy(x => x.nombre).ToList();
    }

    public void ModificarProyecto(Proyecto proyecto)
    {
        try
        {
            var existente = data.GetById(proyecto.id);
            if (existente != null)
            {
                data.Update(proyecto);
            }
            else
            {
                CrearProyecto(proyecto);
            }
        }
        catch
        {
        }
    }
}
