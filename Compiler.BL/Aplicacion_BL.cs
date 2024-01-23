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
            return data.GetAll();
        }

        public List<Aplicacion> getAplicaciones(List<Guid> idsAplicaciones)
        {
            return data.GetAll().Where(x => idsAplicaciones.Contains(x.id)).ToList();
        }

        public void ModificarAplicacion(Aplicacion aplicacion)
        {
            try
            {
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
