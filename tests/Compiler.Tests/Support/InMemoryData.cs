using Compiler.Application.Contracts.Data;

namespace Compiler.Tests.Support;

internal abstract class InMemoryData<T> : IBaseData<T>
    where T : class
{
    protected readonly List<T> Items = [];

    public virtual void CargarDatos()
    {
    }

    public virtual T Add(T dato)
    {
        Items.Add(dato);
        return dato;
    }

    public virtual void Delete(Guid id)
    {
        var item = GetById(id);
        if (item != null)
        {
            Items.Remove(item);
        }
    }

    public virtual List<T> GetAll()
    {
        return [.. Items];
    }

    public abstract T? GetById(Guid id);

    public virtual T Update(T dato)
    {
        return dato;
    }

    public virtual void SaveData()
    {
    }
}