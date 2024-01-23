﻿using Compiler.Shared.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Interface.IBL
{
    public interface IAplicacion_BL
    {
        void BorrarAplicacion(Guid IdAplicacion);
        Aplicacion? CrearAplicacion(Aplicacion aplicacion);
        bool ExisteAplicacion(Guid IdAplicacion);
        Aplicacion getAplicacion(Guid IdAplicacion);
        List<Aplicacion> getAplicaciones();
        List<Aplicacion> getAplicaciones(List<Guid> idsAplicaciones);
        bool AnyAplicacionConArchivoExclusion(Guid idArchivoExclusion);
        void ModificarAplicacion(Aplicacion aplicacion);
    }
}
