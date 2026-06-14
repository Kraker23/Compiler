namespace Compiler.Application.Contracts.Data;

public interface IBaseData<T>
{
    void CargarDatos();
    T? GetById(Guid id);
    List<T> GetAll();
    T Add(T dato);
    T Update(T dato);
    void Delete(Guid id);
    void SaveData();
}