using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.EF
{
    public partial class Carpeta_EF : ICarpeta_Data
    {
        private readonly IManagerJson managerJson;
        public Carpeta_EF(IManagerJson managerJson)
        {
            this.managerJson = managerJson;
            CargarDatos();
        }
        private List<Carpeta> Carpetas { get; set; }
        public void CargarDatos()
        {
            try
            {
                Carpetas = managerJson.cargarDatos<List<Carpeta>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Carpeta Add(Carpeta dato)
        {
            try
            {
                if (!Carpetas.Exists(x => x.id == dato.id))
                {
                    Carpetas.Add(dato);
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
        public List<Carpeta> GetAll()
        {
            try
            {
                return Carpetas;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Carpeta>();
            }
        }

        public Carpeta? GetById(Guid id)
        {
            try
            {
                if (Carpetas.Exists(x => x.id == id))
                {
                    return Carpetas.First(x => x.id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        public Carpeta Update(Carpeta dato)
        {
            try
            {
                Carpetas.First(x => x.id == dato.id).id = dato.id;
                Carpetas.First(x => x.id == dato.id).nombre = dato.nombre;

                Carpeta Aux = Carpetas.First(x => x.id == dato.id);

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
                if (Carpetas.Exists(x => x.id == id))
                {
                    Carpetas.Remove(Carpetas.First(x => x.id == id));
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
                managerJson.GuardarDatos(Carpetas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
