using Compiler.Domain.Entities;

namespace Compiler.Application.Contracts.Services;

public interface IProyectoService
{
    void BorrarProyecto(Guid idProyecto);
    Proyecto? CrearProyecto(Proyecto proyecto);
    bool ExisteProyecto(Guid idProyecto);
    Proyecto? GetProyecto(Guid idProyecto);
    List<Proyecto> GetProyectos();
    bool AnyProyectoConAplicacion(Guid idAplicacion);
    void ModificarProyecto(Proyecto proyecto);
}
