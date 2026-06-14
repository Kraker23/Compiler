using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Interface.IData
{
    public interface IBase_Data<T>
    {
        public void CargarDatos();
        public T? GetById(Guid id);
        public List<T> GetAll();
        public T Add(T dato);
        public T Update(T dato);
        public void Delete(Guid id);
        public void SaveData();
    }
}
