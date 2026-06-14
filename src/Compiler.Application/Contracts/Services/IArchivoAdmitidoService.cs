using Compiler.Domain.Entities;

namespace Compiler.Application.Contracts.Services;

public interface IArchivoAdmitidoService
{
    void BorrarArchivoAdmitido(Guid idArchivoAdmitido);
    ArchivoAdmitido? CrearArchivoAdmitido(ArchivoAdmitido archivoAdmitido);
    bool ExisteArchivoAdmitido(Guid idArchivoAdmitido);
    ArchivoAdmitido? GetArchivoAdmitido(Guid idArchivoAdmitido);
    List<ArchivoAdmitido> GetArchivoAdmitidos();
    List<ArchivoAdmitido> GetArchivoAdmitidos(List<Guid> idsArchivoAdmitidos);
    void ModificarArchivoAdmitido(ArchivoAdmitido archivoAdmitido);
}
