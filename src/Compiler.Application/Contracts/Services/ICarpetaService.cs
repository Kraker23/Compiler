using Compiler.Domain.Entities;

namespace Compiler.Application.Contracts.Services;

public interface ICarpetaService
{
    void BorrarCarpeta(Guid idCarpeta);
    Carpeta? CrearCarpeta(Carpeta carpeta);
    bool ExisteCarpeta(Guid idCarpeta);
    Carpeta? GetCarpeta(Guid idCarpeta);
    List<Carpeta> GetCarpetas();
    List<Carpeta> GetCarpetas(List<Guid> idsCarpetas);
    void ModificarCarpeta(Carpeta carpeta);
}
