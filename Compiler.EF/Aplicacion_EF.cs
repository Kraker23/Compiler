using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.EF
{

    public partial class Aplicacion_EF : IAplicacion_Data
    {
        private readonly IManagerJson managerJson;
        public Aplicacion_EF(IManagerJson managerJson)
        {
            this.managerJson = managerJson;
            CargarDatos();
        }
        private List<Aplicacion> aplicaciones { get; set; }
        public void CargarDatos()
        {
            try
            {
                aplicaciones = managerJson.cargarDatos<List<Aplicacion>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Aplicacion Add(Aplicacion dato)
        {
            try
            {
                if (!aplicaciones.Exists(x => x.id == dato.id))
                {
                    //if (dato.id == 0)
                    //{
                    //    dato.id = aplicaciones.Count() > 0 ? aplicaciones.Max(x => x.id) + 1 : 1;
                    //}
                    aplicaciones.Add(dato);
                    SaveData();
                }
                return dato;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return dato;
            }
        }
        public List<Aplicacion> GetAll()
        {
            try
            {
                return aplicaciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Aplicacion>();
            }
        }

        public Aplicacion? GetById(Guid id)
        {
            try
            {
                if (aplicaciones.Exists(x => x.id == id))
                {
                    return aplicaciones.First(x => x.id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        public Aplicacion Update(Aplicacion dato)
        {
            try
            {
                aplicaciones.First(x => x.id == dato.id).id = dato.id;
                aplicaciones.First(x => x.id == dato.id).nombre = dato.nombre;
                aplicaciones.First(x => x.id == dato.id).ubicacionAplicacion = dato.ubicacionAplicacion;
                aplicaciones.First(x => x.id == dato.id).carpetaCompilado = dato.carpetaCompilado;
                aplicaciones.First(x => x.id == dato.id).carpetaPublicacion = dato.carpetaPublicacion;
                aplicaciones.First(x => x.id == dato.id).comandoCompilado = dato.comandoCompilado;
                aplicaciones.First(x => x.id == dato.id).archivosExcluidos = dato.archivosExcluidos;

                Aplicacion Aux = aplicaciones.First(x => x.id == dato.id);

                SaveData();

                return Aux;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return dato;
            }

        }

        public void Delete(Guid id)
        {
            try
            {
                if (aplicaciones.Exists(x => x.id == id))
                {
                    aplicaciones.Remove(aplicaciones.First(x => x.id == id));
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void SaveData()
        {
            try
            {
                managerJson.GuardarDatos(aplicaciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
