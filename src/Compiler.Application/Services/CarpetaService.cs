using Compiler.Application.Contracts.Data;
using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;

namespace Compiler.Application.Services;

public class CarpetaService(ICarpetaData data) : ICarpetaService
{
    public void BorrarCarpeta(Guid idCarpeta)
    {
        try
        {
            data.Delete(idCarpeta);
        }
        catch
        {
        }
    }

    public Carpeta? CrearCarpeta(Carpeta carpeta)
    {
        try
        {
            return data.Add(carpeta);
        }
        catch
        {
            return null;
        }
    }

    public bool ExisteCarpeta(Guid idCarpeta)
    {
        return data.GetById(idCarpeta) != null;
    }

    public Carpeta? GetCarpeta(Guid idCarpeta)
    {
        return data.GetById(idCarpeta);
    }

    public List<Carpeta> GetCarpetas()
    {
        return data.GetAll().OrderBy(x => x.nombre).ToList();
    }

    public List<Carpeta> GetCarpetas(List<Guid> idsCarpetas)
    {
        return data.GetAll().Where(x => idsCarpetas.Contains(x.id)).OrderBy(x => x.nombre).ToList();
    }

    public void ModificarCarpeta(Carpeta carpeta)
    {
        try
        {
            var existente = data.GetById(carpeta.id);
            if (existente != null)
            {
                data.Update(carpeta);
            }
            else
            {
                CrearCarpeta(carpeta);
            }
        }
        catch
        {
        }
    }
}
