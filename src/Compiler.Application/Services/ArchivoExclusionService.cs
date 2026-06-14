using Compiler.Application.Contracts.Data;
using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;

namespace Compiler.Application.Services;

public class ArchivoExclusionService(IArchivoExclusionData data) : IArchivoExclusionService
{
    public void BorrarArchivoExclusion(Guid idArchivoExclusion)
    {
        try
        {
            data.Delete(idArchivoExclusion);
        }
        catch
        {
        }
    }

    public ArchivoExclusion? CrearArchivoExclusion(ArchivoExclusion archivoExclusion)
    {
        try
        {
            return data.Add(archivoExclusion);
        }
        catch
        {
            return null;
        }
    }

    public bool ExisteArchivoExclusion(Guid idArchivoExclusion)
    {
        return data.GetById(idArchivoExclusion) != null;
    }

    public ArchivoExclusion? GetArchivoExclusion(Guid idArchivoExclusion)
    {
        return data.GetById(idArchivoExclusion);
    }

    public List<ArchivoExclusion> GetArchivoExclusiones()
    {
        return data.GetAll().OrderBy(x => x.texto).ToList();
    }

    public List<ArchivoExclusion> GetArchivoExclusiones(List<Guid> idsArchivoExclusiones)
    {
        return data.GetAll().Where(x => idsArchivoExclusiones.Contains(x.id)).OrderBy(x => x.texto).ToList();
    }

    public void ModificarArchivoExclusion(ArchivoExclusion archivoExclusion)
    {
        try
        {
            var existente = data.GetById(archivoExclusion.id);
            if (existente != null)
            {
                data.Update(archivoExclusion);
            }
            else
            {
                CrearArchivoExclusion(archivoExclusion);
            }
        }
        catch
        {
        }
    }
}
