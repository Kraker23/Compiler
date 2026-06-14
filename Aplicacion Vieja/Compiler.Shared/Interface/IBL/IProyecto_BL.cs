using Compiler.Shared.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Interface.IBL
{
    public interface IProyecto_BL
    {
        void BorrarProyecto(Guid IdProyecto);
        Proyecto? CrearProyecto(Proyecto Proyecto);
        bool ExisteProyecto(Guid IdProyecto);
        Proyecto getProyecto(Guid IdProyecto);
        List<Proyecto> getProyectos();
        bool AnyProyectoConAplicacion(Guid idAplicacion);
        void ModificarProyecto(Proyecto Proyecto);
    }
}
