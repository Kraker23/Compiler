using Compiler.Domain.Entities;

namespace Compiler.Application.Contracts.Services;

public interface IArchivoExclusionService
{
    void BorrarArchivoExclusion(Guid idArchivoExclusion);
    ArchivoExclusion? CrearArchivoExclusion(ArchivoExclusion archivoExclusion);
    bool ExisteArchivoExclusion(Guid idArchivoExclusion);
    ArchivoExclusion? GetArchivoExclusion(Guid idArchivoExclusion);
    List<ArchivoExclusion> GetArchivoExclusiones();
    List<ArchivoExclusion> GetArchivoExclusiones(List<Guid> idsArchivoExclusiones);
    void ModificarArchivoExclusion(ArchivoExclusion archivoExclusion);
}
