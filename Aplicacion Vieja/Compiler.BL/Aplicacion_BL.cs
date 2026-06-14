using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IBL;
using Compiler.Shared.Interface.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.BL
{
    public class Aplicacion_BL : IAplicacion_BL
    {
        private readonly IAplicacion_Data data;

        public Aplicacion_BL(IAplicacion_Data data)
        {
            this.data = data;
        }
        public void BorrarAplicacion(Guid IdAplicacion)
        {
            try
            {
                data.Delete(IdAplicacion);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        public bool AnyAplicacionConArchivoExclusion(Guid idArchivoExclusion)
        {
            return data.GetAll().Any(x => x.archivosExcluidos != null &&  x.archivosExcluidos.Exists(y => y == idArchivoExclusion));
        }
        public bool AnyAplicacionConArchivoAdmitido(Guid idArchivoAdmitido)
        {
            return data.GetAll().Any(x => x.archivosAdmitidos != null && x.archivosAdmitidos.Exists(y => y == idArchivoAdmitido));
        }

        public bool AnyAplicacionConCarpeta(Guid idCarpeta)
        {
            return data.GetAll().Any(x => x.fk_IdCarpeta == idCarpeta);
        }

        public Aplicacion? CrearAplicacion(Aplicacion aplicacion)
        {
            try
            {
                Aplicacion aux = data.Add(aplicacion);
                return aux;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool ExisteAplicacion(Guid IdAplicacion)
        {
            if (data.GetById(IdAplicacion) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Aplicacion getAplicacion(Guid IdAplicacion)
        {
            return data.GetById(IdAplicacion);
        }

        public List<Aplicacion> getAplicaciones()
        {
            return data.GetAll().OrderBy(x => x.nombre).ToList();
        }

        public List<Aplicacion> getAplicaciones(List<Guid> idsAplicaciones)
        {
            return data.GetAll().Where(x => idsAplicaciones.Contains(x.id)).OrderBy(x => x.nombre).ToList();
        }

        public void ModificarAplicacion(Aplicacion aplicacion)
        {
            try
            {
                aplicacion.isNew = false;//Se fuerza que no se guarde este campo en la BBDD
                Aplicacion Aux = data.GetById(aplicacion.id);
                if (Aux != null)
                {
                    data.Update(aplicacion);
                }
                else
                {
                    CrearAplicacion(aplicacion);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        
    }
}
