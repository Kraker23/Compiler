using Compiler.Shared.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler.Shared.Interface.IBL
{
    public interface ICarpeta_BL
    {
        void BorrarCarpeta(Guid IdCarpeta);
        Carpeta? CrearCarpeta(Carpeta Carpeta);
        bool ExisteCarpeta(Guid IdCarpeta);
        Carpeta getCarpeta(Guid IdCarpeta);
        List<Carpeta> getCarpetas();
        List<Carpeta> getCarpetas(List<Guid> idsCarpetas);
        void ModificarCarpeta(Carpeta Carpeta);
    }
}
