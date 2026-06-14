using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.EF
{

    public partial class Proyecto_EF : IProyecto_Data
    {
        private readonly IManagerJson managerJson;
        public Proyecto_EF(IManagerJson managerJson)
        {
            this.managerJson = managerJson;
            CargarDatos();
        }
        private List<Proyecto> proyectos { get; set; }
        public void CargarDatos()
        {
            try
            {
                proyectos = managerJson.cargarDatos<List<Proyecto>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Proyecto Add(Proyecto dato)
        {
            try
            {
                if (!proyectos.Exists(x => x.id == dato.id))
                {
                    proyectos.Add(dato);
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
        public List<Proyecto> GetAll()
        {
            try
            {
                CargarDatos();
                return proyectos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<Proyecto>();
            }
        }

        public Proyecto? GetById(Guid id)
        {
            try
            {
                if (proyectos.Exists(x => x.id == id))
                {
                    return proyectos.First(x => x.id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        public Proyecto Update(Proyecto dato)
        {
            try
            {
                proyectos.First(x => x.id == dato.id).id = dato.id;
                proyectos.First(x => x.id == dato.id).nombre = dato.nombre;
                proyectos.First(x => x.id == dato.id).aplicaciones = dato.aplicaciones;

                Proyecto Aux = proyectos.First(x => x.id == dato.id);

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
                if (proyectos.Exists(x => x.id == id))
                {
                    proyectos.Remove(proyectos.First(x => x.id == id));
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
                managerJson.GuardarDatos(proyectos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
