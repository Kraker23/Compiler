using Compiler.Shared.DataObjects;
using Compiler.Shared.Interface.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.EF
{

    public partial class ArchivoExclusion_EF : IArchivoExclusion_Data
    {
        private readonly IManagerJson managerJson;
        public ArchivoExclusion_EF(IManagerJson managerJson)
        {
            this.managerJson = managerJson;
            CargarDatos();
        }
        private List<ArchivoExclusion> archivoExclusions { get; set; }
        public void CargarDatos()
        {
            try
            {
                archivoExclusions = managerJson.cargarDatos<List<ArchivoExclusion>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public ArchivoExclusion Add(ArchivoExclusion dato)
        {
            try
            {
                if (!archivoExclusions.Exists(x => x.id == dato.id))
                {
                    archivoExclusions.Add(dato);
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
        public List<ArchivoExclusion> GetAll()
        {
            try
            {
                CargarDatos();
                return archivoExclusions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<ArchivoExclusion>();
            }
        }

        public ArchivoExclusion? GetById(Guid id)
        {
            try
            {
                if (archivoExclusions.Exists(x => x.id == id))
                {
                    return archivoExclusions.First(x => x.id == id);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        public ArchivoExclusion Update(ArchivoExclusion dato)
        {
            try
            {
                archivoExclusions.First(x => x.id == dato.id).id = dato.id;
                archivoExclusions.First(x => x.id == dato.id).texto = dato.texto;
                archivoExclusions.First(x => x.id == dato.id).tipoExclusion = dato.tipoExclusion;

                ArchivoExclusion Aux = archivoExclusions.First(x => x.id == dato.id);

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
                if (archivoExclusions.Exists(x => x.id == id))
                {
                    archivoExclusions.Remove(archivoExclusions.First(x => x.id == id));
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
                managerJson.GuardarDatos(archivoExclusions);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

}
