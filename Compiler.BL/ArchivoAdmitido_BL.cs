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
    public class ArchivoAdmitido_BL : IArchivosAdmitido_BL
    {
        private readonly IArchivoAdmitido_Data data;

        public ArchivoAdmitido_BL(IArchivoAdmitido_Data data)
        {
            this.data = data;
        }

        


        public void BorrarArchivoAdmitido(Guid IdArchivoAdmitido)
        {
            try
            {
                data.Delete(IdArchivoAdmitido);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        public ArchivoAdmitido? CrearArchivoAdmitido(ArchivoAdmitido ArchivoAdmitido)
        {
            try
            {
                ArchivoAdmitido aux = data.Add(ArchivoAdmitido);
                return aux;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool ExisteArchivoAdmitido(Guid IdArchivoAdmitido)
        {
            if (data.GetById(IdArchivoAdmitido) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ArchivoAdmitido getArchivoAdmitido(Guid IdArchivoAdmitido)
        {
            return data.GetById(IdArchivoAdmitido);
        }

        public List<ArchivoAdmitido> getArchivoAdmitidos()
        {
            return data.GetAll().OrderBy(x => x.texto).ToList();
        }

        public List<ArchivoAdmitido> getArchivoAdmitidos(List<Guid> idsArchivoAdmitidoes)
        {
            return data.GetAll().Where(x => idsArchivoAdmitidoes.Contains(x.id)).OrderBy(x => x.texto).ToList();
        }
               
        public void ModificarArchivoAdmitido(ArchivoAdmitido ArchivoAdmitido)
        {
            try
            {
                ArchivoAdmitido Aux = data.GetById(ArchivoAdmitido.id);
                if (Aux != null)
                {
                    data.Update(ArchivoAdmitido);
                }
                else
                {
                    CrearArchivoAdmitido(ArchivoAdmitido);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
