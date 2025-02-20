using Compiler.Shared.DataObjects;

namespace Compiler.Shared.Interface.IBL
{
    public interface IArchivosAdmitido_BL
    {
        void BorrarArchivoAdmitido(Guid IdArchivoAdmitido);
        ArchivoAdmitido? CrearArchivoAdmitido(ArchivoAdmitido ArchivoAdmitido);
        bool ExisteArchivoAdmitido(Guid IdArchivoAdmitido);
        ArchivoAdmitido getArchivoAdmitido(Guid IdArchivoAdmitido);
        List<ArchivoAdmitido> getArchivoAdmitidos();
        List<ArchivoAdmitido> getArchivoAdmitidos(List<Guid> idsArchivoAdmitidos);
        void ModificarArchivoAdmitido(ArchivoAdmitido ArchivoAdmitido);
    }
}
