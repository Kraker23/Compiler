using Compiler.Application.Contracts.Data;
using Compiler.Application.Contracts.Services;
using Compiler.Domain.Entities;

namespace Compiler.Application.Services;

public class ArchivoAdmitidoService(IArchivoAdmitidoData data) : IArchivoAdmitidoService
{
    public void BorrarArchivoAdmitido(Guid idArchivoAdmitido)
    {
        try
        {
            data.Delete(idArchivoAdmitido);
        }
        catch
        {
        }
    }

    public ArchivoAdmitido? CrearArchivoAdmitido(ArchivoAdmitido archivoAdmitido)
    {
        try
        {
            return data.Add(archivoAdmitido);
        }
        catch
        {
            return null;
        }
    }

    public bool ExisteArchivoAdmitido(Guid idArchivoAdmitido)
    {
        return data.GetById(idArchivoAdmitido) != null;
    }

    public ArchivoAdmitido? GetArchivoAdmitido(Guid idArchivoAdmitido)
    {
        return data.GetById(idArchivoAdmitido);
    }

    public List<ArchivoAdmitido> GetArchivoAdmitidos()
    {
        return data.GetAll().OrderBy(x => x.texto).ToList();
    }

    public List<ArchivoAdmitido> GetArchivoAdmitidos(List<Guid> idsArchivoAdmitidos)
    {
        return data.GetAll().Where(x => idsArchivoAdmitidos.Contains(x.id)).OrderBy(x => x.texto).ToList();
    }

    public void ModificarArchivoAdmitido(ArchivoAdmitido archivoAdmitido)
    {
        try
        {
            var existente = data.GetById(archivoAdmitido.id);
            if (existente != null)
            {
                data.Update(archivoAdmitido);
            }
            else
            {
                CrearArchivoAdmitido(archivoAdmitido);
            }
        }
        catch
        {
        }
    }
}
