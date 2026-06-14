using Compiler.Shared.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Interface.IBL
{
    public interface IArchivoExclusion_BL
    {
        void BorrarArchivoExclusion(Guid IdArchivoExclusion);
        ArchivoExclusion? CrearArchivoExclusion(ArchivoExclusion ArchivoExclusion);
        bool ExisteArchivoExclusion(Guid IdArchivoExclusion);
        ArchivoExclusion getArchivoExclusion(Guid IdArchivoExclusion);
        List<ArchivoExclusion> getArchivoExclusiones();
        List<ArchivoExclusion> getArchivoExclusiones(List<Guid> idsArchivoExclusiones);
        void ModificarArchivoExclusion(ArchivoExclusion ArchivoExclusion);
    }
}
