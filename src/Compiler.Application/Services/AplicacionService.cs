using Compiler.Application.Contracts.Data;
using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;

namespace Compiler.Application.Services;

public class AplicacionService(IAplicacionData data) : IAplicacionService
{
    public void BorrarAplicacion(Guid idAplicacion)
    {
        try
        {
            data.Delete(idAplicacion);
        }
        catch
        {
        }
    }

    public bool AnyAplicacionConArchivoExclusion(Guid idArchivoExclusion)
    {
        return data.GetAll().Any(x => x.archivosExcluidos != null && x.archivosExcluidos.Exists(y => y == idArchivoExclusion));
    }

    public bool AnyAplicacionConArchivoAdmitido(Guid idArchivoAdmitido)
    {
        return data.GetAll().Any(x => x.archivosAdmitidos != null && x.archivosAdmitidos.Exists(y => y == idArchivoAdmitido));
    }

    public bool AnyAplicacionConCarpeta(Guid idCarpeta)
    {
        return data.GetAll().Any(x => x.fk_IdCarpeta == idCarpeta);
    }

    public Aplicacion? CrearAplicacion(Aplicacion aplicacion)
    {
        try
        {
            return data.Add(aplicacion);
        }
        catch
        {
            return null;
        }
    }

    public bool ExisteAplicacion(Guid idAplicacion)
    {
        return data.GetById(idAplicacion) != null;
    }

    public Aplicacion? GetAplicacion(Guid idAplicacion)
    {
        return data.GetById(idAplicacion);
    }

    public List<Aplicacion> GetAplicaciones()
    {
        return data.GetAll().OrderBy(x => x.nombre).ToList();
    }

    public List<Aplicacion> GetAplicaciones(List<Guid> idsAplicaciones)
    {
        return data.GetAll().Where(x => idsAplicaciones.Contains(x.id)).OrderBy(x => x.nombre).ToList();
    }

    public void ModificarAplicacion(Aplicacion aplicacion)
    {
        try
        {
            aplicacion.isNew = false;
            var existente = data.GetById(aplicacion.id);
            if (existente != null)
            {
                data.Update(aplicacion);
            }
            else
            {
                CrearAplicacion(aplicacion);
            }
        }
        catch
        {
        }
    }
}
