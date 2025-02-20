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
    public class Carpeta_BL : ICarpeta_BL
    {
        private readonly ICarpeta_Data data;

        public Carpeta_BL(ICarpeta_Data data)
        {
            this.data = data;
        }

        


        public void BorrarCarpeta(Guid IdCarpeta)
        {
            try
            {
                data.Delete(IdCarpeta);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        public Carpeta? CrearCarpeta(Carpeta Carpeta)
        {
            try
            {
                Carpeta aux = data.Add(Carpeta);
                return aux;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool ExisteCarpeta(Guid IdCarpeta)
        {
            if (data.GetById(IdCarpeta) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Carpeta getCarpeta(Guid IdCarpeta)
        {
            return data.GetById(IdCarpeta);
        }

        public List<Carpeta> getCarpetas()
        {
            return data.GetAll().OrderBy(x => x.nombre).ToList();
        }

        public List<Carpeta> getCarpetas(List<Guid> idsCarpetas)
        {
            return data.GetAll().Where(x => idsCarpetas.Contains(x.id)).OrderBy(x => x.nombre).ToList();
        }

        public void ModificarCarpeta(Carpeta Carpeta)
        {
            try
            {
                Carpeta Aux = data.GetById(Carpeta.id);
                if (Aux != null)
                {
                    data.Update(Carpeta);
                }
                else
                {
                    CrearCarpeta(Carpeta);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
