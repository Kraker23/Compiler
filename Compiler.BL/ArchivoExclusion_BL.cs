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
    public class ArchivoExclusion_BL : IArchivoExclusion_BL
    {
        private readonly IArchivoExclusion_Data data;

        public ArchivoExclusion_BL(IArchivoExclusion_Data data)
        {
            this.data = data;
        }

        


        public void BorrarArchivoExclusion(Guid IdArchivoExclusion)
        {
            try
            {
                data.Delete(IdArchivoExclusion);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        public ArchivoExclusion? CrearArchivoExclusion(ArchivoExclusion ArchivoExclusion)
        {
            try
            {
                ArchivoExclusion aux = data.Add(ArchivoExclusion);
                return aux;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool ExisteArchivoExclusion(Guid IdArchivoExclusion)
        {
            if (data.GetById(IdArchivoExclusion) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ArchivoExclusion getArchivoExclusion(Guid IdArchivoExclusion)
        {
            return data.GetById(IdArchivoExclusion);
        }

        public List<ArchivoExclusion> getArchivoExclusiones()
        {
            return data.GetAll();
        }

        public List<ArchivoExclusion> getArchivoExclusiones(List<Guid> idsArchivoExclusiones)
        {
            return data.GetAll().Where(x => idsArchivoExclusiones.Contains(x.id)).ToList();
        }

        public void ModificarArchivoExclusion(ArchivoExclusion ArchivoExclusion)
        {
            try
            {
                ArchivoExclusion Aux = data.GetById(ArchivoExclusion.id);
                if (Aux != null)
                {
                    data.Update(ArchivoExclusion);
                }
                else
                {
                    CrearArchivoExclusion(ArchivoExclusion);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
