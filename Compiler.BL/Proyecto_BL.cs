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
    public class Proyecto_BL : IProyecto_BL
    {
        private readonly IProyecto_Data data;

        public Proyecto_BL(IProyecto_Data data)
        {
            this.data = data;
        }

        public bool AnyProyectoConAplicacion(Guid idAplicacion)
        {
            return data.GetAll().Any(x=> x.aplicaciones !=null && x.aplicaciones.Exists(y=>y==idAplicacion));
        }

        public void BorrarProyecto(Guid IdProyecto)
        {
            try
            {
                data.Delete(IdProyecto);
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }

        public Proyecto? CrearProyecto(Proyecto Proyecto)
        {
            try
            {
                Proyecto aux = data.Add(Proyecto);
                return aux;
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool ExisteProyecto(Guid IdProyecto)
        {
            if (data.GetById(IdProyecto) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Proyecto getProyecto(Guid IdProyecto)
        {
            return data.GetById(IdProyecto);
        }


        public List<Proyecto> getProyectoes(List<Guid> idsProyectoes)
        {
            return data.GetAll().Where(x => idsProyectoes.Contains(x.id)).ToList();
        }

        public List<Proyecto> getProyectos()
        {
            return data.GetAll();
        }

        public void ModificarProyecto(Proyecto Proyecto)
        {
            try
            {
                Proyecto Aux = data.GetById(Proyecto.id);
                if (Aux != null)
                {
                    data.Update(Proyecto);
                }
                else
                {
                    CrearProyecto(Proyecto);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
