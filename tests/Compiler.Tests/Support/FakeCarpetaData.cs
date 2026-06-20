using Compiler.Application.Contracts.Data;
using Compiler.Domain.Entities;

namespace Compiler.Tests.Support;

internal sealed class FakeCarpetaData : InMemoryData<Carpeta>, ICarpetaData
{
    public override Carpeta? GetById(Guid id)
    {
        return Items.FirstOrDefault(x => x.id == id);
    }

    public override Carpeta Add(Carpeta dato)
    {
        Items.Add(dato);
        return dato;
    }

    public override Carpeta Update(Carpeta dato)
    {
        var index = Items.FindIndex(x => x.id == dato.id);
        if (index >= 0)
        {
            Items[index] = dato;
        }

        return dato;
    }
}