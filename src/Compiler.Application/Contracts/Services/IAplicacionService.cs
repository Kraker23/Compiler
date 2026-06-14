using Compiler.Domain.Entities;

namespace Compiler.Application.Contracts.Services;

public interface IAplicacionService
{
    void BorrarAplicacion(Guid idAplicacion);
    Aplicacion? CrearAplicacion(Aplicacion aplicacion);
    bool ExisteAplicacion(Guid idAplicacion);
    Aplicacion? GetAplicacion(Guid idAplicacion);
    List<Aplicacion> GetAplicaciones();
    List<Aplicacion> GetAplicaciones(List<Guid> idsAplicaciones);
    bool AnyAplicacionConArchivoExclusion(Guid idArchivoExclusion);
    bool AnyAplicacionConArchivoAdmitido(Guid idArchivoAdmitido);
    bool AnyAplicacionConCarpeta(Guid idCarpeta);
    void ModificarAplicacion(Aplicacion aplicacion);
}
