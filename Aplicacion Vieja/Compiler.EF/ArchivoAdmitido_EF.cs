using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.EF
{

    public partial class ArchivoAdmitido_EF : IArchivoAdmitido_Data
    {
        private readonly IManagerJson managerJson;
        public ArchivoAdmitido_EF(IManagerJson managerJson)
        {
            this.managerJson = managerJson;
            CargarDatos();
        }
        private List<ArchivoAdmitido> archivoAdmitidos { get; set; }
        public void CargarDatos()
        {
            try
            {
                archivoAdmitidos = managerJson.cargarDatos<List<ArchivoAdmitido>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public ArchivoAdmitido Add(ArchivoAdmitido dato)
        {
            try
            {
                if (!archivoAdmitidos.Exists(x => x.id == dato.id))
                {
                    archivoAdmitidos.Add(dato);
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
        public List<ArchivoAdmitido> GetAll()
        {
            try
            {
                CargarDatos();
                return archivoAdmitidos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<ArchivoAdmitido>();
            }
        }

        public ArchivoAdmitido? GetById(Guid id)
        {
            try
            {
                if (archivoAdmitidos.Exists(x => x.id == id))
                {
                    return archivoAdmitidos.First(x => x.id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        public ArchivoAdmitido Update(ArchivoAdmitido dato)
        {
            try
            {
                archivoAdmitidos.First(x => x.id == dato.id).id = dato.id;
                archivoAdmitidos.First(x => x.id == dato.id).texto = dato.texto;
                archivoAdmitidos.First(x => x.id == dato.id).tipoAdmision = dato.tipoAdmision;

                ArchivoAdmitido Aux = archivoAdmitidos.First(x => x.id == dato.id);

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
                if (archivoAdmitidos.Exists(x => x.id == id))
                {
                    archivoAdmitidos.Remove(archivoAdmitidos.First(x => x.id == id));
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
                managerJson.GuardarDatos(archivoAdmitidos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
